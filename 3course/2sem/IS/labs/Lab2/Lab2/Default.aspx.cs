using System;
using System.Net;
using System.IO;

public partial class Default : System.Web.UI.Page
{
    protected void GetButton_Click(object sender, EventArgs e)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:6060/Lab-2/page.SAS?ParmA=Hello&ParmB=World");
        request.Method = "GET";
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        LabelResult.Text = reader.ReadToEnd();
    }

    protected void PostButton_Click(object sender, EventArgs e)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:6060/Lab-2/page.SAS");
        request.Method = "POST";

        byte[] parameters = System.Text.Encoding.UTF8.GetBytes("ParmA=First&ParmB=Second");
        request.ContentLength = parameters.Length;
        request.ContentType = "application/x-www-form-urlencoded";
        var dataStream = request.GetRequestStream();
        dataStream.Write(parameters, 0, parameters.Length);
        dataStream.Close();

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        LabelResult.Text = reader.ReadToEnd();
    }

    protected void PutButton_Click(object sender, EventArgs e)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:6060/Lab-2/page.SAS");
        request.Method = "PUT";

        byte[] parameters = System.Text.Encoding.UTF8.GetBytes("ParmA=Cat&ParmB=Dog");
        request.ContentLength = parameters.Length;
        request.ContentType = "application/x-www-form-urlencoded";
        var dataStream = request.GetRequestStream();
        dataStream.Write(parameters, 0, parameters.Length);
        dataStream.Close();

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        LabelResult.Text = reader.ReadToEnd();
    }

    protected void HeadButton_Click(object sender, EventArgs e)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:6060/Lab-2/page.SAS");
            request.Method = "HEAD";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            LabelResult.Text = reader.ReadToEnd();
        }
        catch (WebException exception)
        {
            LabelResult.Text = exception.Status.ToString();
            LabelResult.Text += "<br />" + exception.Message;
            LabelResult.Text += "<br />" + exception.TargetSite;
            LabelResult.Text += "<br />" + exception.Source;
        }
    }
}