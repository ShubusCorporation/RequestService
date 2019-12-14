using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLBuilder
{
    public class TableBuilder
    {
        StringBuilder m_Bldr = new StringBuilder();
        string m_TableTemplate = 
            @"<h2></h2><center><table border={@borderwidth}>
                <caption>{@caption}</caption>
                      <tr> 
                         {@columns}
                      </tr>
                         {@rows}
              </table></center>";

        string m_ColumnTemplate = "<th>{0}</th>\r\n";
        string m_CellTemplate = "<td>{0}</td>";

        public string BuildTable(string aCaption, List<string> aColumns, List<List<string>> aRows)
        {
            this.m_Bldr = new StringBuilder();
            string columns = "";
            string rows = "";

            foreach (string s in aColumns)
            {
                this.m_Bldr.Append(string.Format(this.m_ColumnTemplate, s));
            }
            columns = this.m_Bldr.ToString();
            this.m_Bldr = new StringBuilder();

            foreach (List<string> ls in aRows)
            {
                this.m_Bldr.Append("<tr>");
                foreach (string s in ls)
                {
                    this.m_Bldr.Append(string.Format(this.m_CellTemplate, s));
                }
                this.m_Bldr.Append("</tr>\r\n");
            }
            rows = this.m_Bldr.ToString();

            this.m_Bldr = new StringBuilder();
            this.m_Bldr.Append(m_TableTemplate);
            this.m_Bldr.Replace("{@borderwidth}", "\"1\"");
            this.m_Bldr.Replace("{@caption}", aCaption);
            this.m_Bldr.Replace("{@columns}", columns);
            this.m_Bldr.Replace("{@rows}", rows);
            return this.m_Bldr.ToString();
        }
    }
}
