using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintManager
{
    public partial class FrmPrintManager : Form
    {
        public FrmPrintManager()
        {
            InitializeComponent();

            this.Start();
        }

        public void Start()
        {

            var data = GET("http://localhost/khos2/public/index.php/api/print-danh-sach-don-hang");

           // object yourOjbect = JsonConvert.DeserializeObject(data);

            object yourOjbect = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic[]>(data);

            Console.WriteLine("DONE");

            //PrintControl printControl = new PrintControl();
            //printControl.getPrinters();
        }

        public string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }
    }
}
