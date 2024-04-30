using ShockRing.Properties;
using Memory;
using System.Media;
using System.Runtime.InteropServices;

namespace ShockRing
{
    public partial class FormMain : Form
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

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

        public int Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                waveOutSetVolume(IntPtr.Zero, ((uint)_volume & 0x0000ffff) | ((uint)_volume << 16));
            }
        }

        public Mem? _process;
        private uint? _previousHp;
        private bool _died;
        private bool _active;
        private SoundPlayer _soundPlayer;
        private int _volume;

        public FormMain()
        {
            InitializeComponent();
            Select();

            _soundPlayer = new();
            Volume = 0;

            Active = false;

        } // end constructor

        private async void MainLoop()
        {
            while (true)
            {
                if (_process == null) Active = false;
                if (!Active) return;

                uint hp = _process.ReadUInt("base+03AA3DA0,0,460,190,0,138");
                uint mhp = _process.ReadUInt("base+03CE2650,90");

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
                    UpdateCurrentTime();
                    textBoxActivate.Text = $"You died.";
                    PlaySound(Resources.aaaa);
                }
                // Detect hp lower
                else if (hp != _previousHp)
                {
                    if (hp != 0 && _previousHp != null && hp < _previousHp)
                    {
                        uint lost = (uint)_previousHp - hp;
                        float percent = MathF.Round((float)lost / mhp * 100f, 2);
                        UpdateCurrentTime();
                        textBoxActivate.Text = $"Damaged for {lost} hp. ({percent}%, {lost}/{mhp})";
                        PlaySound(Resources.bonk);
                    }
                    _previousHp = hp;
                }

                await Task.Delay(30);
            }

        } // end MainLoop

        private void PlaySound(UnmanagedMemoryStream stream)
        {
            _soundPlayer.Stream = stream;
            _soundPlayer.Play();

        } // end PlaySound

        private void UpdateCurrentTime()
        {
            textBoxActivateTimestamp.Text = DateTime.Now.ToLongTimeString();

        } // end UpdateCurrentTime

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

        private void trackBarSFX_Scroll(object sender, EventArgs e)
        {
            Volume = ushort.MaxValue / trackBarSFX.Maximum * trackBarSFX.Value;

        } // end trackBarSFX_Scroll

    } // end class FormMain

} // end namespace ShockRing