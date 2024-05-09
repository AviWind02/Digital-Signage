using Re_DigitalSignage.Utilities;

namespace Re_DigitalSignage
{
    public partial class MainForm : Form
    {
        private DirectoryManager directoryManager;
        private RegistrationManager registrationManager;
        private DualWriter dualWriter;

        public MainForm()
        {
            InitializeComponent();
            directoryManager = new DirectoryManager();
            registrationManager = new RegistrationManager();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Used to created the log file
            dualWriter.StartLogging();

            Console.WriteLine("Start.");
            // Start up stuff
            directoryManager.Run();
            registrationManager.CreateMainDirectory();
        }
    }
}
