using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ical.Net;

namespace iCalReader
{
    public partial class frmMain : Form
    {
        string _filename;
        public frmMain(string filename = null)
        {
            _filename = filename;

            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (_filename == null)
                return;

            var calendar = Calendar.Load(new StreamReader(_filename, true));
            var events = calendar.Events;

            StringBuilder sb = new StringBuilder();
            foreach (var ev in events)
            {
                sb.Append("Summary:     " + ev.Summary + Environment.NewLine);
                sb.Append("Location:    " + ev.Location + Environment.NewLine);
                sb.Append("Start:       " + ev.Start + Environment.NewLine);
                sb.Append("Duration:    " + ev.Duration + Environment.NewLine);
                sb.Append("End:         " + ev.End + Environment.NewLine);
                sb.Append("------------ " + Environment.NewLine);
                sb.Append("Attendees:   " + Environment.NewLine);
                foreach (var att in ev.Attendees)
                {
                    sb.Append("* " + att.CommonName + Environment.NewLine);
                }
                sb.Append("------------ " + Environment.NewLine);
                sb.Append("Description: " + ev.Description + Environment.NewLine);
            }

            txtInfo.Text = sb.ToString();

            txtInfo.Select(0,0);
        }
    }
}
