using Memory;

namespace ShockRing
{
    public partial class FormMain : Form
    {
        public bool Active
        {
            get { return _active; }
            private set
            {
                _active = value;
                if (_active)
                {
                    _died = false;
                    _previousHp = null;

                    // Open Elden Ring process
                    _process = new Mem();
                    if (!_process.OpenProcess("eldenring"))
                    {
                        _active = false;
                        labelActive.Text = "Can't find Elden Ring.";
                    }
                    else
                        labelActive.Text = "Currently active.";
                }
                else
                    labelActive.Text = "Currently inactive.";
            }
        }

        public Mem? _process;
        private int? _previousHp;
        private bool _died;
        private bool _active;

        public FormMain()
        {
            InitializeComponent();
            Select();

            Active = false;

        } // end constructor

        private async void MainLoop()
        {
            while (true)
            {
                if (_process == null) Active = false;
                if (!Active) return;

                int hp = _process.ReadInt("base+03AA3DA0,0,460,190,0,138");
                int mhp = _process.ReadInt("base+03CE2650,90");

                // Back to life
                if (_died)
                {
                    if (hp != 0)
                        _died = false;
                }
                // Death
                else if (!_died && hp == 0)
                {
                    _died = true;
                    Console.WriteLine("Died.");
                }
                // Detect hp lower
                else if (hp != _previousHp)
                {
                    if (hp != 0 && _previousHp != null && hp < _previousHp)
                    {
                        int lost = (int)_previousHp - hp;
                        float percent = MathF.Round((float)lost / mhp * 100f, 2);

                        textBoxActivateTimestamp.Text = DateTime.Now.ToLongTimeString();
                        textBoxActivate.Text = $"Damaged for {lost} hp. ({percent}%, {lost}/{mhp})";
                    }
                    _previousHp = hp;
                }

                await Task.Delay(30);
            }

        } // end MainLoop

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Active = false;

        } // end buttonStop_Click

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (Active) return;

            Active = true;
            Task.Run(MainLoop);

        } // end buttonStart_Click

    } // end class FormMain

} // end namespace ShockRing