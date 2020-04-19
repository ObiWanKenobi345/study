using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace HtmlElements1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Select.Items.Add("Item 1");
                Select.Items.Add("Item 2");
                Select.Items.Add("Item 3");

                HtmlTable htmlTable = new HtmlTable();
                htmlTable.Border = 1;
                htmlTable.CellPadding = 3;
                htmlTable.CellSpacing = 3;
                htmlTable.Align = "center";
                htmlTable.BorderColor = "black";
                htmlTable.Style.Add("border-collapse", "collapse");
                htmlTable.ID = "HtmlTable";

                HtmlTableRow titlesRow = new HtmlTableRow();

                HtmlTableCell cell = new HtmlTableCell();
                cell.InnerHtml = "Html Control";
                titlesRow.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = "onserverclick";
                titlesRow.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = "onserverchange";
                titlesRow.Cells.Add(cell);

                htmlTable.Rows.Add(titlesRow);

                HtmlTableRow resetButtonRow = new HtmlTableRow();

                cell = new HtmlTableCell();
                cell.InnerHtml = "HtmlInputReset";
                resetButtonRow.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = "NO";
                resetButtonRow.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = "NO";
                resetButtonRow.Cells.Add(cell);

                htmlTable.Rows.Add(resetButtonRow);

                this.Controls.Add(htmlTable);

                Session["HtmlTable"] = htmlTable;
            }
        }

        protected void Button_ServerClick(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlInputButton", true, false);
        }

        protected void SubmitButton_ServerClick(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlInputSubmit", true, false);
        }

        protected void InputText_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlInputText", false, true);
        }

        protected void CheckBox_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlInputCheckbox", false, true);
        }

        private void AddRowToHtmlTable(string elementName, bool onServerClick, bool onServerChange)
        {
            HtmlTable htmlTable = Session["HtmlTable"] as HtmlTable;

            if (htmlTable != null)
            {
                HtmlTableRow row = new HtmlTableRow();

                HtmlTableCell cell = new HtmlTableCell();
                cell.InnerHtml = elementName;
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = onServerClick == true ? "YES" : "NO";
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = onServerChange == true ? "YES" : "NO";
                row.Cells.Add(cell);

                htmlTable.Rows.Add(row);

                this.Controls.Add(htmlTable);
            }
        }

        protected void Radio1_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("Radio1", false, true);
        }

        protected void Radio2_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("Radio2", false, true);
        }

        protected void TextArea_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlTextArea", false, true);
        }

        protected void Select_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlSelect", false, true);
        }
    }
}