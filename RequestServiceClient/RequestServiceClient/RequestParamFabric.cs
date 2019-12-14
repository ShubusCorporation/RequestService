using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RequestService.RequestServiceReference;

namespace RequestServiceDektopApp
{
    class RequestParamFabric
    {
        public BaseRequestParams Create(RequestType aType, DataGridView RequestGrid)
        {
            BaseRequestParams param = null;

            switch (aType)
            {
                case RequestType.REQUEST_SELDON:
                    param = new RequestService.RequestServiceReference.SeldonRequestParams()
                    {
                        seldonVersion = Version.Parse((string)(RequestGrid.Rows[0].Cells[0].Value)),
                        price = Int32.Parse((string)(RequestGrid.Rows[0].Cells[1].Value)),
                        garante = DateTime.Parse((string)(RequestGrid.Rows[0].Cells[2].Value))                     
                    };

                    if (((SeldonRequestParams)param).seldonVersion.Build < 0 || ((SeldonRequestParams)param).seldonVersion.Revision < 0)
                    {
                        int major = ((SeldonRequestParams)param).seldonVersion.Major < 0 ? 0 : ((SeldonRequestParams)param).seldonVersion.Major;
                        int minor = ((SeldonRequestParams)param).seldonVersion.Minor < 0 ? 0 : ((SeldonRequestParams)param).seldonVersion.Minor;

                        ((SeldonRequestParams)param).seldonVersion = new Version(major, minor, 0, 0);
                    }
                    break;

                case RequestType.REQUEST_JUSTICE:

                    param = new RequestService.RequestServiceReference.JusticeRequestParams()
                    {
                        price = Int32.Parse((string)(RequestGrid.Rows[0].Cells[0].Value)),
                        phone = (string)(RequestGrid.Rows[0].Cells[1].Value),
                        courtAddress = (string)(RequestGrid.Rows[0].Cells[2].Value),
                        loyerName = (string)(RequestGrid.Rows[0].Cells[3].Value),
                        debtorName = (string)(RequestGrid.Rows[0].Cells[4].Value)
                    };
                    break;

                case RequestType.REQUEST_LEARNING:

                    param = new RequestService.RequestServiceReference.LearningRequestParams()
                    {
                        course = (string)(RequestGrid.Rows[0].Cells[0].Value),
                        price = Int32.Parse((string)(RequestGrid.Rows[0].Cells[1].Value)),
                        lector = (string)(RequestGrid.Rows[0].Cells[2].Value),
                        address = (string)(RequestGrid.Rows[0].Cells[3].Value)
                    };
                    break;

                default:
                    break;
            }
            return param;
        }
    }
}