using BEL_Allotment;
using DLL_Allotment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Allotment
{
    public class Mbal
    {//26 oct
        public DataSet CheckIssueletter(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.CheckIssueletter(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }

        }
        //
        //20
        public DataSet GetApplicationOfPIPFINObjection(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.GetApplicationOfPIPFINObjection(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet GetApplicationOfPIPFINApproved(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.GetApplicationOfPIPFINApproved(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet GetApplicationForPIPFINUnderProcess(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.GetApplicationForPIPFINUnderProcess(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        //17
        public DataSet BindTotalCountCompleted(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.BindTotalCountCompleted(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        //11 oct
        public Int32 SaveObjectionResponsePIP(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.SaveObjectionResponsePIP(objBel);
            }
            catch (Exception ex)
            {
                return 0;  //       throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public Int32 RaiseObjectionPIP(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.RaiseObjectionPIP(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        // 10oct
        public Int32 SaveDirectorsDetailsPIP(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.SaveDirectorsDetailsPIP(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public Int32 Sp_SaveShareHoldersDetailPIPFIN(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.Sp_SaveShareHoldersDetailPIPFIN(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet SavePIPFinDetails(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.SavePIPFinDetails(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }

        //
        // 25/sep2023
        public Int32 SaveDirectorsDetailsPIPFIN(Mpropertymodel objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.SaveDirectorsDetailsPIPFIN(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        //end code
        //21sep

        public DataSet GetApplicationOfPIPFINInBox(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.GetApplicationOfPIPFINInBox(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        //public DataSet GetAlertApplicationOfPIPFINInBox(belBookDetails objBel)
        //{
        //    Mdal objDal = new Mdal();
        //    try
        //    {
        //        return objDal.GetAlertApplicationOfPIPFINInBox(objBel);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        objDal = null;
        //    }
        //}
        public DataSet GetApplicationOfPIPFINRejected(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.GetApplicationOfPIPFINRejected(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        // end code
        public Int32 FormFinalSubmissionPIP(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.FormFinalSubmissionPIP(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet GetServiceChecklistsLAW_SP_BY_Condtion(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.GetServiceChecklistsLAW_SP_BY_Condtion(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet GetPIPCheckListDocument(belBookDetails objBel)
        {

            Mdal objDal = new Mdal();

            try
            {
                return objDal.GetPIPCheckListDocument(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public Int32 SavePIPServiceChecklistDocument(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.SavePIPServiceChecklistDocument(objBel);
            }
            catch (Exception ex)
            {
                return 0;  //       throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet GetAllServiceChecklistsPIP(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.GetAllServiceChecklistsPIP(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }

        public DataSet CheckemailidforaloteeRegister(string email)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.CheckemailidforaloteeRegister(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet Checkformid(Mpropertymodel objpmodel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.Checkformid(objpmodel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet GetPIP_AFADetails(Mpropertymodel objbel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.GetPIP_AFADetails(objbel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet GetPIP_AFA_ProjectDetails(Mpropertymodel objbel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.GetPIP_AFA_ProjectDetails(objbel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
      
        public Int32 SaveApplicationforAvailingFinancialAssistance(Mpropertymodel objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.SaveApplicationforAvailingFinancialAssistance(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        // signature save finaly test SaveApplicantImagefIP
        public Int32 SaveApplicantImagefIP(Mpropertymodel objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.SaveApplicantImagefIP(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        // signature save finaly test SaveApplicantSignfin
        public Int32 SaveApplicantSignfin(Mpropertymodel objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.SaveApplicantSignfin(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet UpdateApplicantFINBasicDetails(Mpropertymodel objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.UpdateApplicantfinBasicDetails(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public Int32 Save_and_update_ProjectDetails(Mpropertymodel objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.Save_and_update_ProjectDetails(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet GetAFinancialAssistanceDetails(Mpropertymodel objbel)
        {
            Mdal objdal = new Mdal();
            try
            {
                return objdal.GetAFinancialAssistanceDetails(objbel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }
        public Int32 AddLAWLandDetails(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.AddLAWLandDetails(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public Int32 UpdateLAWLandDetails(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.UpdateLAWLandDetails(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }

        public Int32 DeleteLAWLandDetail(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.DeleteLAWLandDetail(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
        public DataSet GetLAWLandDetails(belBookDetails objBel)
        {
            Mdal objDal = new Mdal();
            try
            {
                return objDal.GetLAWLandDetails(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }
    }
}