using System;
using System.Net;
using System.IO;

namespace Lab2
{
    public partial class Math : System.Web.UI.Page
    {
        protected void SumButton_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = HttpWebRequest.Create("http://localhost:6060/Lab-2/path.math") as HttpWebRequest;
            request.Method = "POST";

            int x = int.Parse(XTextBox.Text);
            int y = int.Parse(YTextBox.Text);
            string postData = "x=" + x + "&y=" + y;

            byte[] parameters = System.Text.Encoding.UTF8.GetBytes(postData);
            request.ContentLength = parameters.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            var dataStream = request.GetRequestStream();
            dataStream.Write(parameters, 0, parameters.Length);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            ResultTextBox.Text = reader.ReadToEnd();
        }
    }
}