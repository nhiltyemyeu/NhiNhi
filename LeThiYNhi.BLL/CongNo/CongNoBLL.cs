using LeThiYNhi.DAO.CongNo;
using LeThiYNhi.DTO.CongNo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeThiYNhi.BLL.CongNo
{
    public class CongNoBLL
    {
        CongNoDAO dal = new CongNoDAO();
        public List<CongNoDTO> ReadCN()
        {
            List<CongNoDTO> lstCn = dal.ReadCN();
            return lstCn;
        }

        public void NewCustomer(CongNoDTO cno)
        {
            dal.NewCustomer(cno);
        }

        public void DeleteCustomer(CongNoDTO cno)
        {
            dal.DeleteCustomer(cno);
        }

        public void EditCustomer(CongNoDTO cno)
        {
            dal.EditCustomer(cno);
        }
    }
}
