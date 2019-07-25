using System;
using System.Windows.Forms;

namespace HaoZhuoCRM.Utils
{
    public class ListViewHelper
    {
        public static Int32? getIndexByText(ListView listView, string text)
        {
            foreach (ColumnHeader header in listView.Columns)
            {
                if (header.Text == text)
                {
                    return header.Index;
                }
            }
            return null;
        }
    }
}
