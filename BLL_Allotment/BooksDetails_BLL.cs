using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using BEL_Allotment;
using DLL_Allotment;


namespace BLL_Allotment

{
    public class BooksDetails_BLL
    {
        #region LandAcquisition
        public DataSet GetCourtType()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCourtType();
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
        public DataSet GetCaseType()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCaseType();
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

        public DataSet GetLandADetailwithParameter(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetLandADetailwithParameter(objBel);
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
        public DataSet GetDistrictRecords()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetDistrictRecords();
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

        #region  InsertRecords
        public DataSet NewRegistrationLandAcquispitionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.NewRegistrationLandAcquispitionDetails(objBel);
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
        public DataSet LANotificationDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LANotificationDetails(objBel);
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

        public DataSet LAPossessionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LAPossessionDetails(objBel);
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

        public DataSet LAAwardsDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LAAwardsDetails(objBel);
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

        public DataSet LAConveyenceDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LAConveyenceDetails(objBel);
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

        public DataSet LAPaymentDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LAPaymentDetails(objBel);
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


        public DataSet LACompansationDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LACompansationDetails(objBel);
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

        public DataSet LALitigationDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LALitigationDetails(objBel);
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
        #endregion

        #region DeleteRecords
        public DataSet LANotificationDeleteDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LANotificationDeleteDetails(objBel);
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
        public DataSet LAPossessionDeleteDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LAPossessionDeleteDetails(objBel);
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
        public DataSet LAAwardDeleteDetails_sp(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LAAwardDeleteDetails_sp(objBel);
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
        public DataSet LAConveyenceDeedsDeleteDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LAConveyenceDeedsDeleteDetails(objBel);
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
        public DataSet LAPaymentDeleteDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LAPaymentDeleteDetails(objBel);
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

        public DataSet LACompansationDeleteDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LACompansationDeleteDetails(objBel);
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

        public DataSet LALitigationDeleteDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.LALitigationDeleteDetails(objBel);
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

        #endregion

        public DataSet GetLandAcuisitionDetailsFilledById(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetLandAcuisitionDetailsFilledById(objBel);
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

        public DataSet GetIANameNameRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIANameNameRecords(objBel);
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

        public DataSet GetPossessionDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPossessionDetails(objBel);
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

        public DataSet GetPossessionGridDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPossessionGridDetails(objBel);
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

        public DataSet GetNotificationDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetNotificationDetails(objBel);
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

        public DataSet GetNotificationGridDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetNotificationGridDetails(objBel);
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

        public DataSet GetAwardDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAwardDetails(objBel);
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

        public DataSet GetAwardGridDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAwardGridDetails(objBel);
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


        public DataSet GetConveyenceDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetConveyenceDetails(objBel);
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

        public DataSet GetConveyenceGridDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetConveyenceGridDetails(objBel);
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

        public DataSet GetPaymentDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPaymentDetails(objBel);
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

        public DataSet GetPaymentGridDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPaymentGridDetails(objBel);
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


        public DataSet GetCompansationDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCompansationDetails(objBel);
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

        public DataSet GetCompansationGridDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCompansationGridDetails(objBel);
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


        public DataSet GetLitigationDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetLitigationDetails(objBel);
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

        public DataSet GetLitigationGridDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetLitigationGridDetails(objBel);
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
        #endregion
        #region "Amalgamation Post Allotment"


        public DataSet SetServiceRequestIAServiceInHouse(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestIAServiceInHouse(objBel);
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

        public DataSet GetApplicationOfAmalgamationPostAllotment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfAmalgamationPostAllotment(objBel);
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
        //--------Test--------
        public DataSet GetApplicationOfLidaAllotment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLidaAllotment(objBel);
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

        public DataSet GetApplicationOfAmalgamationPostAllotmentUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfAmalgamationPostAllotmentUnderProcess(objBel);
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

        public DataSet GetApplicationOfAmalgamationPostAllotmentCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfAmalgamationPostAllotmentCompleted(objBel);
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

        public Int32 ClearPreviousSubdividedPlotDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearPreviousSubdividedPlotDetails(objBel);
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

        public Int32 SaveSubdividedPlots(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveSubdividedPlots(objBel);
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

        public Int32 InsertAmalgamationDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertAmalgamationDetails(objBel);
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

        public DataSet GetPlotAdjacencyDetailsPostAmalgamation(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPlotAdjacencyDetailsPostAmalgamation(objBel);
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
        public DataSet GetPlotsForAmalgamationPostAllotment(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPlotsForAmalgamationPostAllotment(objBel);
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

        #endregion


        #region "Logistic & Warehousing"

        public Int32 SaveCommentsDescriptionLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveCommentsDescriptionLAW(objBel);
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
        public Int32 SaveCommentsDescriptionPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveCommentsDescriptionPIP(objBel);
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
        public Int32 ClearCommentsDescriptionLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearCommentsDescriptionLAW(objBel);
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
        
        public Int32 ClearCommentsDescriptionPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearCommentsDescriptionPIP(objBel);
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
        public Int32 UpdateEvaluationDetailsLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateEvaluationDetailsLAW(objBel);
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
        public Int32 UpdateEvaluationDetailsPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateEvaluationDetailsPIP(objBel);
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
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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
        public Int32 DeletePIPLandDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeletePIPLandDetail(objBel);
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
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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
        public DataSet GetPIPLandDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetPIPLandDetails(objBel);
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
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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
        public Int32 UpdatePIPLandDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdatePIPLandDetails(objBel);
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
        public Int32 AddLAWLandDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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
        public Int32 AddPIPLandDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.AddPIPLandDetails(objBel);
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
        public DataSet GetApplicationOfLogisticWarehousingApproved(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLogisticWarehousingApproved(objBel);
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

        public DataSet GetApplicationOfPIPApproved(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfPIPApproved(objBel);
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

        public DataSet GetAlertApplicationOfPIPApproved(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAlertApplicationOfPIPApproved(objBel);
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

        public DataSet GetApplicationOfLogisticWarehousingRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLogisticWarehousingRejected(objBel);
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
        public DataSet GetApplicationOfPIPRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfPIPRejected(objBel);
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

        public DataSet GetAlertApplicationOfPIPRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAlertApplicationOfPIPRejected(objBel);
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


        public DataSet GetApplicationOfPIPObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfPIPObjection(objBel);
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

        public DataSet GetAlertApplicationOfPIPObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAlertApplicationOfPIPObjection(objBel);
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

        public Int32 IssueLetterLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.IssueLetterLAW(objBel);
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
        public Int32 IssueLetterPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.IssueLetterPIP(objBel);
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

        public DataSet GetAllMeetingMinutesLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllMeetingMinutesLAW(objBel);
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

        public DataSet GetAllMeetingMinutesPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllMeetingMinutesPIP(objBel);
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

        public DataSet GetUserForwardedList(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetUserForwardedList(objBel);
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

        public Int32 DeleteMeetingMinutesLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteMeetingMinutesLAW(objBel);
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

        public Int32 DeleteMeetingMinutesPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteMeetingMinutesPIP(objBel);
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


        public Int32 UpdateMeetingMinutesLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateMeetingMinutesLAW(objBel);
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

        public Int32 UpdateMeetingMinutesPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateMeetingMinutesPIP(objBel);
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



        public Int32 InsertMeetingMinutesLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertMeetingMinutesLAW(objBel);
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

        public Int32 InsertMeetingMinutesPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertMeetingMinutesPIP(objBel);
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

        public Int32 SaveObjectionResponseLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveObjectionResponseLAW(objBel);
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
        public Int32 SaveObjectionResponsePIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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
        public Int32 RaiseObjectionLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.RaiseObjectionLAW(objBel);
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
        public Int32 RaiseObjectionPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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


        public DataSet GetApplicationOfLogisticWarehousingUnderProcess1(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLogisticWarehousingUnderProcess1(objBel);
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
        public DataSet GetApplicationOfPIPUnderProcess1(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfPIPUnderProcess1(objBel);
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
        

        public DataSet GetAlertApplicationOfPIPUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAlertApplicationOfPIPUnderProcess(objBel);
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


        public Int32 UpdateLawComments(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateLawComments(objBel);
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
        public Int32 UpdatePIPComments(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdatePIPComments(objBel);
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



        public DataSet GetApplicationOfLogisticWarehousingInBox1(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLogisticWarehousingInBox1(objBel);
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
        public DataSet GetApplicationOfPIPInBox1(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfPIPInBox1(objBel);
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

        public DataSet Get_Notesheet_of_application_LAW(string ServiceReqNo)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.Get_Notesheet_of_application_LAW(ServiceReqNo);
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
        public DataSet Get_Notesheet_of_application_PIP(string ServiceReqNo)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.Get_Notesheet_of_application_PIP(ServiceReqNo);
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
        public Int32 TransferApplicationLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.TransferApplicationLAW(objBel);
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

        public Int32 TransferCommitteeApplicationPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.TransferCommitteeApplicationPIP(objBel);
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
        


        public Int32 TransferApplicationPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.TransferApplicationPIP(objBel);
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
        public Int32 UpdateCorrespondenceDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateCorrespondenceDetails(objBel);
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


        public Int32 DeleteCorrespondenceLetters(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteCorrespondenceLetters(objBel);
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


        public Int32 InsertCorrespondenceLetters(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertCorrespondenceLetters(objBel);
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


        public DataSet GetAllCorrespondenceLetters(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllCorrespondenceLetters(objBel);
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


        public DataSet GetLAWDocumentByID(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetLAWDocumentByID(objBel);
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

        public DataSet GetPIPDocumentByID(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPIPDocumentByID(objBel);
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

        public DataSet GetApplicationOfLogisticWarehousingInBox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLogisticWarehousingInBox(objBel);
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

        public DataSet GetApplicationOfPIPInBox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfPIPInBox(objBel);
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

        public DataSet GetAlertApplicationOfPIPInBox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAlertApplicationOfPIPInBox(objBel);
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

        public DataSet GetAlertCommStatus(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAlertCommStatus(objBel);
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

        public Int32 FormFinalSubmissionLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.FormFinalSubmissionLAW(objBel);
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

        public Int32 FormFinalSubmissionPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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

        public DataSet GetLAWCheckListDocument(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetLAWCheckListDocument(objBel);
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

            BooksDetails_DAL objDal = new BooksDetails_DAL();

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

        public Int32 SaveLAWServiceChecklistDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveLAWServiceChecklistDocument(objBel);
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

        public Int32 SavePIPServiceChecklistDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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

        public DataSet GetAllServiceChecklistsLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllServiceChecklistsLAW(objBel);
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

        public DataSet GetAllServiceChecklistsPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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

        public Int32 UpdateApplicantProjectDetailsLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantProjectDetailsLAW(objBel);
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

        public Int32 UpdateApplicantProjectDetailsPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantProjectDetailsPIP(objBel);
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


        public Int32 SaveApplicantSignLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantSignLAW(objBel);
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

        public Int32 SaveApplicantSignPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantSignPIP(objBel);
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

        public Int32 SaveMigrationDetailsLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveMigrationDetailsLAW(objBel);
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
        public Int32 SaveMigrationDetailsPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveMigrationDetailsPIP(objBel);
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
        public Int32 SaveApplicantImageLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantImageLAW(objBel);
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

        public Int32 SaveApplicantImagePIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantImagePIP(objBel);
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


        public Int32 SavePartnerDetailsLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SavePartnerDetailsLAW(objBel);
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

        public Int32 SavePartnerDetailsPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SavePartnerDetailsPIP(objBel);
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

        public Int32 SaveTrusteeDetailsLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTrusteeDetailsLAW(objBel);
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

        public Int32 SaveTrusteeDetailsPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTrusteeDetailsPIP(objBel);
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


        public Int32 SaveDirectorsDetailsLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveDirectorsDetailsLAW(objBel);
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
        public Int32 SaveDirectorsDetailsPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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


        public Int32 SaveShareHolderDetailsLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveShareHolderDetailsLAW(objBel);
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

        public Int32 SaveShareHolderDetailsPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveShareHolderDetailsPIP(objBel);
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


        public Int32 ClearFirmConstitutionLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearFirmConstitutionLAW(objBel);
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
        public Int32 ClearFirmConstitutionPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearFirmConstitutionPIP(objBel);
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


        public DataSet UpdateApplicantLAWBasicDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantLAWBasicDetails(objBel);
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

        public DataSet UpdateApplicantPIPBasicDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantPIPBasicDetails(objBel);
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


        public DataSet GetLAWDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetLAWDetails(objBel);
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

        public DataSet GetPIPDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetPIPDetails(objBel);
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

        public DataSet SaveLogisticDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveLogisticDetails(objBel);
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

        public DataSet SaveReScDueDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveReScDueDetails(objBel);
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
        


        public DataSet SavePIPDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SavePIPDetails(objBel);
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
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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


        #endregion


        #region "LAD"
        public Int32 UpdateLAStatus(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateLAStatus(objBel);
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
        public DataSet GetgridforLADClosed(belBookDetails objBEL)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetgridforLADClosed(objBEL);
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

        public DataSet GetgridStatus(string search)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetgridStatus(search);
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
        public Int32 RevertLAStatus(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.RevertLAStatus(objBel);
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

        public DataSet GetgridLADClosed(belBookDetails objBEL)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetgridLADClosed(objBEL);

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


        #endregion
        // mashi 15 Dec
        public DataSet ViewSignedCopyLetterSbiEAUCtion(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.ViewSignedCopyLetterSbiEAUCtion(objBel);
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
        public Int32 UploadSignedCopyLetterSbiauction(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadSignedCopyLetterSbiauction(objBel);
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
        // end code mashi
        public DataSet GetApplicationOfSubDivisionPostAllotment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfSubDivisionPostAllotment(objBel);
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

        public DataSet GetApplicationForSubDivisionPostAllotmentUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationForSubDivisionPostAllotmentUnderProcess(objBel);
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

        public DataSet GetApplicationOfSubDivisionPostAllotmentUnderObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfSubDivisionPostAllotmentUnderObjection(objBel);
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

        public DataSet GetApplicationOfSubDivisionPostAllotmentCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfSubDivisionPostAllotmentCompleted(objBel);
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

        public DataSet GetApplicationOfSubDivisionPostAllotmentRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfSubDivisionPostAllotmentRejected(objBel);
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

        #region TimeExtenstion
        public DataSet GetapplicableChargesforTimeExtenstionView(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesforTimeExtenstionView(objBel);
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
        public DataSet GetapplicableChargesforTimeExtenstionNMSWPPaid(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesforTimeExtenstionNMSWPPaid(objBel);
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
        #endregion

        #region "MIS Investment"

        public DataSet GetListOfInvestmentIAWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfInvestmentIAWise(objBel);
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

        public DataSet GetListOfOutstandingWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfOutstandingWise(objBel);
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

        public DataSet GetListOfPublishedPlots(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfPublishedPlots(objBel);
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


        #endregion
        #region New AllotteeMasterDetail


        public DataSet GetAllotteeIDDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeIDDetails(objBel);
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
        #region UploadCACertificateDocument

        public Int32 UploadCACertificateDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadCACertificateDocument(objBel);
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

        public DataSet GetBindUploadedDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetBindUploadedDocument(objBel);
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

        public DataSet GetCheckListDocumentAllotteeRegistration(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCheckListDocumentAllotteeRegistration(objBel);
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

        public DataSet GetCompletedAlloteeDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetCompletedAlloteeDetail(objBel);
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

        public Int32 UpdateAllotteeProjectDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateAllotteeProjectDetails(objBel);
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



        #endregion

        public Int32 NewAllotteeRegistration(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.NewAllotteeRegistration(objBel);
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

        public Int32 AllotteeKYA(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.AllotteeKYA(objBel);
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
        public DataSet NewRegistrationAllotteeDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.NewRegistrationAllotteeDetails(objBel);
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
        public Int32 ClearAllotteeShareHolder(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearAllotteeShareHolder(objBel);
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

        public Int32 SaveAllotteeShareHolderDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveAllotteeShareHolderDetails(objBel);
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

        public Int32 SaveAllotteeDirectorsDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveAllotteeDirectorsDetails(objBel);
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

        public Int32 SaveAllotteeTrusteeDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveAllotteeTrusteeDetails(objBel);
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

        public Int32 SaveAllotteePatnersDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveAllotteePatnersDetails(objBel);
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

        public DataSet GetPreServiceDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetPreServiceDetails(objBel);
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

        public DataSet GetProductSubCategory(string HSC)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetProductSubCategory(HSC);
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

        public DataSet GetProductCategory()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetProductCategory();
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

        public DataSet GetHSCProductName(string HSC)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetHSCProductName(HSC);
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
        #endregion

        #region "MD Appointment"


        public Int32 CloseCeoAppointment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.CloseCeoAppointment(objBel);
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

        public Int32 RejectCeoAppointment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.RejectCeoAppointment(objBel);
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

        public Int32 ApproveCeoAppointment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ApproveCeoAppointment(objBel);
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
        public DataSet GetAppointmentRecieved(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAppointmentRecieved(objBel);
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

        public DataSet GetAppointmentCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAppointmentCompleted(objBel);
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

        public DataSet GetAppointmentRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAppointmentRejected(objBel);
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
        public DataSet GetAppointmentApproved(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAppointmentApproved(objBel);
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
        public DataSet GetAppointeeDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAppointeeDetails(objBel);
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

        public DataSet GetAllIADistrictWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllIADistrictWise(objBel);
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

        public DataSet GetAllDistrictRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllDistrictRecords(objBel);
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

        public Int32 UpdateCeoAppointmentDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateCeoAppointmentDetails(objBel);
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
        public DataSet SaveCEOAppointmentDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveCEOAppointmentDetails(objBel);
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

        #endregion

        #region "Office Order"

        public DataSet GetOfficeOrdersPublic()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetOfficeOrdersPublic();
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

        public Int32 DeleteOfficeOrder(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteOfficeOrder(objBel);
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
        public Int32 UpdateOfficeOrderMaster(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateOfficeOrderMaster(objBel);
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
        public DataSet GetOfficeOrdersList()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetOfficeOrdersList();
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

        public Int32 SaveOfficeOrder(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveOfficeOrder(objBel);
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

        #endregion

        #region "Facility Master"
        public DataSet GetapplicableChargesforTransferPlotNMSWPPaid(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesforTransferPlotNMSWPPaid(objBel);
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
        public Int32 UpdateAcknowledgementTransferNew(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateAcknowledgementTransferNew(objBel);
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
        public DataSet GetTransferLevyCalculation(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetTransferLevyCalculation(objBel);
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
        public DataSet GetListOfFeeNMSWPReceived(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfFeeNMSWPReceived(objBel);
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

        public DataSet GetListOfFeeNMSWPReceivedGST(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfFeeNMSWPReceivedGST(objBel);
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


        public DataSet GetListOfTotalFeeReceived(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfTotalFeeReceived(objBel);
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


        public Int32 ParkEntryInParkMasterInstant(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ParkEntryInParkMasterInstant(objBel);
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

        public Int32 PlotEntryInPlotMasterInstant(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.PlotEntryInPlotMasterInstant(objBel);
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


        public Int32 DeleteFacilityFromMaster(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteFacilityFromMaster(objBel);
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


        public DataSet BindFacilityInTextBox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindFacilityInTextBox(objBel);
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
        public DataSet BindFacilityInListbox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindFacilityInListbox(objBel);
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
        public Int32 FacilityEntryInFacilityMaster(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.FacilityEntryInFacilityMaster(objBel);
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



        #endregion



        #region IAService Wise Report


        public DataSet GetListOfAllIAApplictionsDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfAllIAApplictionsDetails(objBel);
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


        public DataSet Get_IAServiceList(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Get_IAServiceList(objBel);
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
        public DataSet Get_IAService_ROList(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Get_IAService_ROList(objBel);
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
        #endregion


        #region IA Service Report

        public DataSet Get_IAService_ListNew(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Get_IAService_ListNew(objBel);
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
        public DataSet Get_IAService_ReginalofficeList(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Get_IAService_ReginalofficeList(objBel);
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
        #endregion

        public DataSet SetServiceRequestIAServiceNMSWP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestIAServiceNMSWP(objBel);
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

        public Int32 SetServiceRequestFinishIAServiceOutstandingDues(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestFinishIAServiceOutstandingDues(objBel);
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

        #region IAMaster


        public DataSet GetNGOCdistictRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetNGOCdistictRecords(objBel);
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
        public DataSet GetSubDistict(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetSubDistict(objBel);
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

        public DataSet GetVillage(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetVillage(objBel);
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
        #endregion

        #region "New Manish Rastogi Method"


        public DataSet GetNewReconstitutionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetNewReconstitutionDetails(objBel);
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

        public Int32 ClearFirmConstitutionOfReconstitution(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearFirmConstitutionOfReconstitution(objBel);
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
        public DataSet UpdateReconstitutionDetailsNew(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateReconstitutionDetailsNew(objBel);
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

        #endregion



        #region Restorationofplot




        public DataSet GetapplicableChargesforReconstitutionNMSWP(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesforReconstitutionNMSWP(objBel);
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
        public DataSet GetapplicableChargesforRecognitionNMSWP(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesforRecognitionNMSWP(objBel);
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
        public Int32 InsertRestorationofplot(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertRestorationofplot(objBel);
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
        public DataSet GetAllotteeDetailsIAServiceModule1(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeDetailsIAServiceModule1(objBel);
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
        public DataSet GetRestorationDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetRestorationDetails(objBel);
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

        public Int32 InsertServiceCustomSetApplicantDataforRestoration(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertServiceCustomSetApplicantDataforRestoration(objBel);
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

        #endregion

        #region SurrenderofPlot
        public Int32 InsertSurrenderofPlot(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertSurrenderofPlot(objBel);
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

        public DataSet GetSurrenderDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetSurrenderDetails(objBel);
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
        #endregion

        #region SublettingofPlot
        public Int32 InsertSublettingofPlot(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertSublettingofPlot(objBel);
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

        public DataSet GetSublettingDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetSublettingDetails(objBel);
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

        public Int32 SaveApplicantImageforSubletting(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantImageforSubletting(objBel);
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

        public Int32 SaveApplicantSignforSubletting(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantSignforSubletting(objBel);
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

        public Int32 UpdateApplicantProjectDetailsforSubletting(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantProjectDetailsforSubletting(objBel);
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

        public DataSet UpdateApplicantDetailsforSubletting(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantDetailsforSubletting(objBel);
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

        public Int32 ClearShareHolderforSubletting(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearShareHolderforSubletting(objBel);
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

        public Int32 SaveShareHolderDetailsforSubletting(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveShareHolderDetailsforSubletting(objBel);
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
        public Int32 SaveDirectorsDetailsforSubletting(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveDirectorsDetailsforSubletting(objBel);
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

        public Int32 SaveTrusteeDetailsforSubletting(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTrusteeDetailsforSubletting(objBel);
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

        public Int32 SavePartnerDetailsforSubletting(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SavePartnerDetailsforSubletting(objBel);
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


        public Int32 InsertServiceCustomSetApplicantDataforSubletting(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertServiceCustomSetApplicantDataforSubletting(objBel);
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
        #endregion

        #region Additional Unit
        public Int32 InsertAdditionalUnit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertAdditionalUnit(objBel);
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

        public DataSet GetAdditionalUnitDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAdditionalUnitDetails(objBel);
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
        #endregion

        #region hand over of lease deed

        public DataSet GethandoverofleasedeedDetailsIAService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GethandoverofleasedeedDetailsIAService(objBel);
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
        public Int32 InserthandoverofleasedeedtoleaseDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InserthandoverofleasedeedtoleaseDetails(objBel);
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
        #endregion
        #region Water Connection
        public Int32 InsertWaterConnectionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertWaterConnectionDetails(objBel);
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
        #endregion
        #region reconstitution
        public DataSet GetAllAllotteeDetailsFilledforReconstitution(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllAllotteeDetailsFilledforReconstitution(objBel);
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
        public DataSet GetreconstitutionDetailsIAService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetreconstitutionDetailsIAService(objBel);
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
        public DataSet bindshareholdergried(string AllotteeId)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.bindshareholdergried(AllotteeId);
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
        public DataSet bindDirectorsGrid(string AllotteeId)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.bindDirectorsGrid(AllotteeId);
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

        public DataSet bindTrustee_details_grid(string AllotteeId)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.bindTrustee_details_grid(AllotteeId);
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

        public DataSet bindPartnershipFirmGrid(string AllotteeId)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.bindPartnershipFirmGrid(AllotteeId);
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

        public Int32 InsertReconsitutionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertReconsitutionDetails(objBel);
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
        public Int32 Insertshareholderdetails(string AlloteeId, string ShareholderName, decimal shareper, string Address, string phone, string email)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Insertshareholderdetails(AlloteeId, ShareholderName, shareper, Address, phone, email);
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
        public Int32 InsertDirectordetails(string AlloteeId, string DirectorName, string din_pan, string Address, string phone, string email)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertDirectordetails(AlloteeId, DirectorName, din_pan, Address, phone, email);
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
        public Int32 InsertTrusteedetails(string AlloteeId, string TrusteeName, string Address, string phone, string email)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertTrusteedetails(AlloteeId, TrusteeName, Address, phone, email);
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
        public Int32 InsertPartnerdetails(string AlloteeId, string PartnerName, decimal Partnershipper, string Address, string phone, string email)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertPartnerdetails(AlloteeId, PartnerName, Partnershipper, Address, phone, email);
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
        #endregion

        #region  NiveshMitra Intrigration
        public Int32 SetServiceRequestFinish_IAService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestFinish_IAService(objBel);
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

        public DataSet ServiceApplicableChargeforSubletting(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ServiceApplicableChargeforSubletting(objBel);
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

        #endregion


        #region  Plot Cancelation

        public DataSet Get_NoticeWithAllotteeInternal(string ServiceReqNo)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.Get_NoticeWithAllotteeInternal(ServiceReqNo);
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

        public DataSet PlotCancelationApplicantDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.PlotCancelationApplicantDetails(objBel);
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


        public Int32 InsertPlotCancelationDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertPlotCancelationDetails(objBel);
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



        public DataSet ViewSignedCopyNotice(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.ViewSignedCopyNotice(objBel);
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

        public Int32 UploadNotice(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadNotice(objBel);
            }
            catch (Exception)
            {
                return 0;  //       throw ex;
            }
            finally
            {
                objDal = null;
            }
        }

        public Int32 InsertServiceCustomSetApplicantDataforNotice(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertServiceCustomSetApplicantDataforNotice(objBel);
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

        public DataSet Get_NoticeWithAllottee(string ServiceReqNo)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.Get_NoticeWithAllottee(ServiceReqNo);
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

        public DataSet CreateNotice(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.CreateNotice(objBel);
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

        public DataSet SetRequestIAPlotCancelation(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetRequestIAPlotCancelation(objBel);
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

        public Int32 SetServiceRequestFinishCancelationofplot(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestFinishCancelationofplot(objBel);
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
        #endregion


        #region StartofProduction
        public DataSet GetAllotteeDetailsIAStartofProductionService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeDetailsIAStartofProductionService(objBel);
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

        public Int32 InsertStartofProductionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertStartofProductionDetails(objBel);
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


        public DataSet GetStartofProductionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetStartofProductionDetails(objBel);
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
        #endregion

        #region "Transfer Of plot"

        public DataSet GetTransferApplicableCase()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetTransferApplicableCase();
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
        public DataSet GetApplicableChargesIAServicesNMSWPPay(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicableChargesIAServicesNMSWPPay(objBel);
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
        public DataSet GetapplicableChargesforTransferPlotNMSWP(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesforTransferPlotNMSWP(objBel);
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
        public Int32 SaveSignTransferar(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveSignTransferar(objBel);
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
        public Int32 SaveImageTransferar(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveImageTransferar(objBel);
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
        public DataSet GetapplicableChargesforTransferPlotAmount(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesforTransferPlotAmount(objBel);
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
        public DataSet GetapplicableChargesforTransferPlot(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesforTransferPlot(objBel);
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
        public Int32 UpdateAcknowledgementTransfer(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateAcknowledgementTransfer(objBel);
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
        public DataSet CheckTransferPlotAcknowledgement(belBookDetails objBel)
        {


            BooksDetails_DAL objDal = new BooksDetails_DAL();


            try

            {

                return objDal.CheckTransferPlotAcknowledgement(objBel);

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
        public Int32 UpdateTransferarAccountsDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateTransferarAccountsDetails(objBel);
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
        public Int32 UpdateTransfreeProjectDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateTransfreeProjectDetails(objBel);
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
        public Int32 SaveApplicantSignTransfree(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantSignTransfree(objBel);
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

        public Int32 SaveApplicantImageTransfree(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantImageTransfree(objBel);
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

        public Int32 SavePartnerDetailsTransfree(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SavePartnerDetailsTransfree(objBel);
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
        public Int32 SaveTrusteeDetailsTransfree(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTrusteeDetailsTransfree(objBel);
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
        public Int32 SaveDirectorsDetailsTransfree(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveDirectorsDetailsTransfree(objBel);
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

        public Int32 SaveShareHolderDetailsTransfree(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveShareHolderDetailsTransfree(objBel);
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
        public Int32 ClearFirmConstitution(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearFirmConstitution(objBel);
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
        public DataSet UpdateTransfreeDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateTransfreeDetails(objBel);
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


        public DataSet GetTransfreeBasicDetails(belBookDetails objBel)
        {


            BooksDetails_DAL objDal = new BooksDetails_DAL();


            try

            {

                return objDal.GetTransfreeBasicDetails(objBel);

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

        public DataSet GetTransfreeDocuments(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetTransfreeDocuments(objBel);
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

        public DataSet GetTransferarDocuments(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetTransferarDocuments(objBel);
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

        public Int32 SaveTransferarChecklistDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTransferarChecklistDocument(objBel);
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

        public DataSet GetTransferarDocumentsView(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetTransferarDocumentsView(objBel);
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

        public DataSet GetTransfreeDocumentsView(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetTransferarDocumentsView(objBel);
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

        #endregion

        #region "NMSWP New Payment Flow"

        public Int32 FinalSubmissionWithoutFee(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.FinalSubmissionWithoutFee(objBel);
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
        public DataSet GetLeaseDeedPaymentDetailAfterTransactionNMSWP(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetLeaseDeedPaymentDetailAfterTransactionNMSWP(objBel);
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
        public DataSet GetTransactionDetailsNMSWP(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetTransactionDetailsNMSWP(objBel);
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

        public DataSet GetTransactionDetailsNMSWPLAW(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetTransactionDetailsNMSWPLAW(objBel);
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

        public DataSet GetTransactionDetailsNMSWPPIP(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetTransactionDetailsNMSWPPIP(objBel);
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

        public Int32 SaveTransactionDetailsNMSWPLAW(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTransactionDetailsNMSWPLAW(objBel);
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
        #endregion

        public Int32 SaveTransactionDetailsNMSWPPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTransactionDetailsNMSWPPIP(objBel);
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

        public Int32 SaveTransactionDetailsNMSWPPIPCom(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTransactionDetailsNMSWPPIPCom(objBel);
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

        public Int32 UpdateTransactionDetailsNMSWPPIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateTransactionDetailsNMSWPPIP(objBel);
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

        #region "IAService NMSWP"
        public DataSet VerifyOTPIAService(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.VerifyOTPIAService(objBel);
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
        public Int32 SaveOTPIAServicesNMSWP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveOTPIAServicesNMSWP(objBel);
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

        #endregion

        #region IAServiceAccountDetails
        public DataSet GetgridServiceTracker(String ServiceID)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridServiceTracker(ServiceID);

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

        public DataSet GetAllotmentletterDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotmentletterDetails(objBel);
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
        public DataSet GetListOfIAServiceAccountDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfIAServiceAccountDetails(objBel);
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

        public DataSet GetListOfIAServiceAccountDetailsCleared(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfIAServiceAccountDetailsCleared(objBel);
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

        public Int32 UpdateApplicationAfterAccountClearenceIAService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicationAfterAccountClearenceIAService(objBel);
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
        #endregion


        #region Letter Upload
        public DataSet GetgridLetterUpload(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridLetterUpload(objBel);

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
        public DataSet InsertletteruploadDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertletteruploadDetails(objBel);
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
        public DataSet UpdateletteruploadDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateletteruploadDetails(objBel);
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

        #endregion

        #region "GEtdemandNoteOFAllottee"


        public DataSet GEtdemandNoteOFAllottee(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GEtdemandNoteOFAllottee(objBel);
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
        #endregion


        #region 'Distict Update NMSWP'

        public Int32 UpdateDistrictInNMSWPInDB(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateDistrictInNMSWPInDB(objBel);
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


        #endregion


        #region "qpr"

        public Int32 insertQPR(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.insertQPR(objBel);
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

        public Int32 UpdateQPR(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateQPR(objBel);
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

        public DataSet GetEditQPRDetails(string id)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetEditQPRDetails(id);

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


        public Int32 Delete_QPRdetals(string id)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Delete_QPRdetals(id);
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

        #endregion


        #region "Plot Avalaibility by manish Rastogi"


        public DataSet GetgridforLandoffred1(int id)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridforLandoffred1(id);

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

        public DataSet GetDistrictNameRecords(int DistrictID)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetDistrictNameRecords(DistrictID);

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

        public DataSet Getgridplotavailability(int IA)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.Getgridplotavailability(IA);

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

        public DataSet Getgridplotareawise(int IA, int AreaID)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.Getgridplotareawise(IA, AreaID);

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


        public DataSet GetgridLASforviewmore(string ID)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridLASforviewmore(ID);

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


        public DataSet getSubDistrictRecords(int DistrictID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.getSubDistrictRecords(DistrictID);
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


        public DataSet InsertLandAssessmentDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertLandAssessmentDetails(objBel);
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


        public DataSet GetgridLAD(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
               return objDal.GetgridLAD(objBel);
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



        public DataSet GetgridforLAD(belBookDetails objBEL)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetgridforLAD(objBEL);
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

        public DataSet Getgridforviewmore(string ID)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.Getgridforviewmore(ID);

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


        public DataSet InsertLandAcquisitionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertLandAcquisitionDetails(objBel);
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

        public Int32 InsertLanddetails(int LandAcquisitionID, string Village, string KhataNo, string KhatedarName, string FatherHusbandName, string Address, string GataNo, string GataArea)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertLanddetails(LandAcquisitionID, Village, KhataNo, KhatedarName, FatherHusbandName, Address, GataNo, GataArea);
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


        public DataSet GetgridLAP()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridLAP();

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

        public DataSet GetgridforSearch(string search)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridforSearch(search);

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

        public DataSet GetgridforLandoffred(int id)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridforLandoffred(id);

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

        public DataSet GetgridForView(string ID)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridForView(ID);

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
        #endregion


        #region "Resubmission Building plan"
        public DataSet VerifyOTPBPResubmission(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.VerifyOTPBPResubmission(objBel);
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
        public Int32 SaveOTPBPResubmission(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveOTPBPResubmission(objBel);
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
        public DataSet GetIADistrictWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetIADistrictWise(objBel);
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
        public Int32 SetServiceRequestFinishBPResubmission(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestFinishBPResubmission(objBel);
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
        public Int32 UpdateBPResubmission(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateBPResubmission(objBel);
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

        #endregion

        #region  POA

        public DataSet GetgridPOA()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridPOA();

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


        public DataSet InsertPOADetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertPOADetails(objBel);
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


        public DataSet UpdatePOADetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdatePOADetails(objBel);
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


        public Int32 Delete_POAdetals(string id)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Delete_POAdetals(id);
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

        public DataSet GetEditDetails(string id)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetEditDetails(id);

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


        public DataSet GetgridPOAforSearch(string search)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridPOAforSearch(search);

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

        #endregion
        
        #region IAMaster Updated

        public DataSet GetReleventDocView(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetReleventDocView(objBel);
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
        public Int32 UploadReleventDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadReleventDocument(objBel);
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
        #endregion


        #region "RefundClearence"

        public DataSet GetRefundAccountDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetRefundAccountDetails(objBel);
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

        public DataSet GetListOfApplicationRefundCleared(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfApplicationRefundCleared(objBel);
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
        public Int32 UpdateApplicationAfterRefundClearence(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicationAfterRefundClearence(objBel);
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
        public DataSet GetListOfApplicationForRefundClearance(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfApplicationForRefundClearance(objBel);
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

        #endregion

        #region TEFApplication

        public DataSet ListOfPlotForReservationMoney(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ListOfPlotForReservationMoney(objBel);
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
        public DataSet GetIndustrialAreaDetailSelected(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIndustrialAreaDetailSelected(objBel);
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
        public DataSet GetDocumentChecklistTimeextenstion(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetDocumentChecklistTimeextenstion(objBel);
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
        public DataSet GetStatusForApproval_TEF(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetStatusForApproval_TEF(objBel);
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


        public DataSet GetApplicationOfTEFInBox_AutoApproval(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfTEFInBox_AutoApproval(objBel);
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


        public Int32 UploadSignedCopyLetter_TEF(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadSignedCopyLetter_TEF(objBel);
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


        public DataSet ViewTEFApprovalLetter(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ViewTEFApprovalLetter(objBel);
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



        public DataSet GetAllAllotteeDetailsforTEF(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllAllotteeDetailsforTEF(objBel);
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
        public Int32 DeleteTEFDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteTEFDetails(objBel);
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

        public DataSet GetApplicationOfTEFCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfTEFCompleted(objBel);
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

        public DataSet GetApplicationOfTEFUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfTEFUnderProcess(objBel);
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

        public Int32 InsertServiceCustomSetApplicantDataforTEF(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertServiceCustomSetApplicantDataforTEF(objBel);
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
        public Int32 TransferApplicationTEF(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.TransferApplicationTEF(objBel);
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



        public DataSet Get_Notesheet_of_TEFapplication(string ServiceReqNo)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.Get_Notesheet_of_TEFapplication(ServiceReqNo);
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



        public DataSet GetPaymentDetailTransactionWiseTEF(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPaymentDetailTransactionWiseTEF(objBel);
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


        public Int32 SetServiceRequestFinishTEF(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestFinishTEF(objBel);
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

        public Int32 SetServiceRequestFinishReservationMoney(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestFinishReservationMoney(objBel);
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

        public DataSet GetApplicantTEFDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicantTEFDetails(objBel);
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

        public Int32 ClearTimeExtensionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearTimeExtensionDetails(objBel);
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
        public Int32 InsertAllotteeTEFDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertAllotteeTEFDetails(objBel);
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


        public DataSet GetTEFPaymentDetailAfterTransaction(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetTEFPaymentDetailAfterTransaction(objBel);
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
        public DataSet GetApplicationOfTEFInBox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfTEFInBox(objBel);
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


        public DataSet GetChargesforTEF(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetChargesforTEF(objBel);
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




        public DataSet GetAllotteeDetailsTEFAll(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeDetailsTEFAll(objBel);
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


        public DataSet SetServiceRequestTEF(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.SetServiceRequestTEF(objBel);
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




        public DataSet GetapplicableChargesforTEF(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesforTEF(objBel);
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

        public DataSet TEFPeriodBinding(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.TEFPeriodBinding(objBel);
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

        #endregion

        #region Timeextensionfee
        public DataSet GetTimeextensionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetTimeextensionDetails(objBel);
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


        public DataSet GetAllotteeDetailsIATimeextensionService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeDetailsIATimeextensionService(objBel);
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

        public Int32 InsertTimeextensionfeeDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertTimeextensionfeeDetails(objBel);
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

        #endregion

        #region  Transfer of Lease deed to Financial Institution

        public Int32 InserttransferofleasedeedDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InserttransferofleasedeedDetails(objBel);
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
        public DataSet GettransferofleasedeedDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GettransferofleasedeedDetails(objBel);
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

        public DataSet GetAllotteeDetailsIAtransferofleasedeedService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeDetailsIAtransferofleasedeedService(objBel);
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
        #endregion


        #region Noc for Mortgage
        public Int32 InsertNocMortgageDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertNocMortgageDetails(objBel);
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
        public DataSet GetNocMortgageDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetNocMortgageDetails(objBel);
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

        public DataSet GetApplicationOfSecondChargeRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfSecondChargeRejected(objBel);
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

        public DataSet GetApplicationOfNocMortgageRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfNocMortgageRejected(objBel);
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

        public DataSet GetApplicationOfMortgageRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfMortgageRejected(objBel);
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
        public DataSet GetAllotteeDetailsIAMortgageService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeDetailsIAMortgageService(objBel);
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

        #endregion

        #region  Method

        public Int32 SetServiceRequestFinishSecondCharge(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestFinishSecondCharge(objBel);
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
        #endregion

        #region   Second charge

        public DataSet GetAllotteeDetailsIASecondchargeService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeDetailsIASecondchargeService(objBel);
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

        public DataSet GetApplicationOfIAUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfIAUnderProcess(objBel);
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



        public DataSet GetSecondchargeDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetSecondchargeDetails(objBel);
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



        public Int32 InsertSecondchargeDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertSecondchargeDetails(objBel);
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
        #endregion


        #region  Joint Mortgage

        public Int32 InsertBankDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertBankDetails(objBel);
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
        public Int32 InsertJointMortgageDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertJointMortgageDetails(objBel);
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

        public DataSet GetJointMortgageDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetJointMortgageDetails(objBel);
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

        public DataSet GetAllotteeDetailsIAJointMortgageService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeDetailsIAJointMortgageService(objBel);
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
        #endregion


        #region "IAServices"
        public Int32 UploadObjectionDocOnly(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadObjectionDocOnly(objBel);
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

        public DataSet ListOfPlotForIAServices(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ListOfPlotForIAServices(objBel);
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


        public Int32 RaisePaymentObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.RaisePaymentObjection(objBel);
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

        public Int32 DeleteAllotteeLedgerEntry(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteAllotteeLedgerEntry(objBel);
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


        public Int32 InsertAllotteeLedgerEntry(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertAllotteeLedgerEntry(objBel);
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

        public DataSet GetAllotteeForLedgerEntry(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotteeForLedgerEntry(objBel);
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

        public DataSet GetPlotForAucEntry(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPlotForAucEntry(objBel);
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
        public DataSet BindTotalCountUnderObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindTotalCountUnderObjection(objBel);
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

        public DataSet BindTotalCountCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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

        public DataSet BindTotalCountRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindTotalCountRejected(objBel);
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


        public DataSet BindTotalCountUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindTotalCountUnderProcess(objBel);
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


        public DataSet BindTotalCountInbox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindTotalCountInbox(objBel);
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

        public DataSet BindTotalCountInboxHOLA(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindTotalCountInboxHOLA(objBel);
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
        public DataSet BindTotalCountInboxTEFAuto(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindTotalCountInboxTEFAuto(objBel);
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

        public Int32 InsertBuildingSpecification(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertBuildingSpecification(objBel);
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

        public Int32 InsertAdditionalProductDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertAdditionalProductDetails(objBel);
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

        public DataSet GetApplicationOfChangeOfProjectRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfChangeOfProjectRejected(objBel);
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


        public DataSet GetApplicationOfChangeOfProjectCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfChangeOfProjectCompleted(objBel);
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

        public DataSet GetApplicationOfChangeOfProjectUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfChangeOfProjectUnderProcess(objBel);
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

        public DataSet GetApplicationOfChangeOfProjectUnderObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfChangeOfProjectUnderObjection(objBel);
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


        public Int32 SaveObjectionResponseIAServices(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveObjectionResponseIAServices(objBel);
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

        public Int32 SetServiceRequestFinishIAServiceDues(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestFinishIAServiceDues(objBel);
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

        public Int32 RaiseObjectionIAService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.RaiseObjectionIAService(objBel);
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

        public Int32 DemandNoteDetailEntryIAService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DemandNoteDetailEntryIAService(objBel);
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

        public DataSet ObjectionPlusDemandRaise(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ObjectionPlusDemandRaise(objBel);
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

        public DataSet GetApplicationOfChangeOfProjectInBox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfChangeOfProjectInBox(objBel);
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

        public Int32 SetServiceRequestFinishIAService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestFinishIAService(objBel);
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
        public DataSet GetApplicableChargesIAServicesView(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicableChargesIAServicesView(objBel);
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

        public DataSet GetAllotteeDetailsIAService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeDetailsIAService(objBel);
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

        public DataSet GetApplicableChargesIAServices(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicableChargesIAServices(objBel);
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

        public DataSet GetPaidChargesIAServices(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetPaidChargesIAServices(objBel);
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

        public DataSet GetChangeOfProjectDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetChangeOfProjectDetails(objBel);
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
        public Int32 InsertChangeOfProjectDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertChangeOfProjectDetails(objBel);
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

        public DataSet GetCheckListDocumentAllIAServices(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCheckListDocumentAllIAServices(objBel);
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
        public DataSet GetAllServiceChecklistsIAServices(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllServiceChecklistsIAServices(objBel);
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
        public DataSet SetServiceRequestIAService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestIAService(objBel);
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

        #endregion

        #region "Lease Deed"
        public DataSet Get_application_status_History(string ServiceReqNo)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.Get_application_status_History(ServiceReqNo);
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


        public DataSet GetApplicationOfPossessionCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfPossessionCompleted(objBel);
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

        public DataSet GetApplicationOfLeaseDeedCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLeaseDeedCompleted(objBel);
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

        public Int32 SavePossessionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SavePossessionDetails(objBel);
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

        public Int32 UploadPlotPossessionMemo(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadPlotPossessionMemo(objBel);
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
        public DataSet CreateAppointmentForPossession(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.CreateAppointmentForPossession(objBel);
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

        public DataSet GetApplicationOfLeaseDeedUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLeaseDeedUnderProcess(objBel);
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

        public Int32 UploadSignedLeaseDeed(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadSignedLeaseDeed(objBel);
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
        public Int32 UploadPlotLeaseDeed(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadPlotLeaseDeed(objBel);
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

        public Int32 SaveLeaseDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveLeaseDetails(objBel);
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

        public Int32 UploadGMIDCLetter(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadGMIDCLetter(objBel);
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

        public DataSet UpdateROAppoitmentDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateROAppoitmentDetails(objBel);
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

        public Int32 TransferApplicationLease(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.TransferApplicationLease(objBel);
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
        public Int32 SaveJESiteLeaseDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveJESiteLeaseDetails(objBel);
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

        public Int32 UploadInspectionReportLeaseDeed(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadInspectionReportLeaseDeed(objBel);
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

        public Int32 UploadPlotTracingLeaseDeed(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadPlotTracingLeaseDeed(objBel);
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


        public Int32 AssignPOA(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.AssignPOA(objBel);
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

        public Int32 InsertAckDocLease(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertAckDocLease(objBel);
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

        public Int32 ClearAckDoc(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearAckDoc(objBel);
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

        public Int32 UploadPOAPhoto(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadPOAPhoto(objBel);
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

        public DataSet CloseLeaseDeedAppointment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.CloseLeaseDeedAppointment(objBel);
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

        public DataSet Get_AppointmentsWithAllottee(string ServiceReqNo)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.Get_AppointmentsWithAllottee(ServiceReqNo);
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

        public DataSet CreateAppointmentForLeaseDeed(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.CreateAppointmentForLeaseDeed(objBel);
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

        public DataSet GetApplicationOLeaseDeedInBox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOLeaseDeedInBox(objBel);
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

        public DataSet GetApplicationOLeaseDeedRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOLeaseDeedRejected(objBel);
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
        public DataSet GetApplicationOLeaseDeedUnderObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOLeaseDeedUnderObjection(objBel);
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

        public DataSet GetLeaseDeedPaymentDetailAfterTransaction(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetLeaseDeedPaymentDetailAfterTransaction(objBel);
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

        public Int32 SetServiceRequestFinishLeaseDeed(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestFinishLeaseDeed(objBel);
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

        public DataSet GetApplicableChargesLeaseDeedFee(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicableChargesLeaseDeedFee(objBel);
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

        public DataSet GetApplicableChargesLeaseDeed(string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetApplicableChargesLeaseDeed(serviceID);
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


        public DataSet SetServiceRequestLeaseDeed(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestLeaseDeed(objBel);
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

        public DataSet GetAllotteeRecordToBindForApplication(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotteeRecordToBindForApplication(objBel);
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

        public DataSet GetAllotteeRecordToBindForLeaseDeed(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotteeRecordToBindForLeaseDeed(objBel);
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

        public DataSet GetDocumentChecklistLeaseDeed(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetDocumentChecklistLeaseDeed(objBel);
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

        #endregion



        #region "UserCreation"

        public DataSet GetBuildingPlanChargesAll(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBuildingPlanChargesAll(objBel);
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
        public DataSet GetDesignationDetails()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetDesignationDetails();

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


        public DataSet GetgridforUsercreation()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridforUsercreation();

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

        public DataSet InsertUserDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertUserDetails(objBel);
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

        public DataSet UpdateUserDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateUserDetails(objBel);
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

        public DataSet GetUserDetails(string id)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetUserDetails(id);

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

        public Int32 Delete_Userdetals(string id)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Delete_Userdetals(id);
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


        public DataSet GetgridforSearchUsercreation(string search)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetgridforSearchUsercreation(search);

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



        #endregion

        #region TEF

        public DataSet GetListOfAllAPplictionsIA(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfAllAPplictionsIA(objBel);
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
        public Int32 InsertTEFDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertTEFDetails(objBel);
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
        #endregion

        #region "Reservation Money"

        public DataSet GetDetailsWithReservationMoneyNew(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try

            {

                return objDal.GetDetailsWithReservationMoneyNew(objBel);

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
        public DataSet GetReservationPaymentDetailAfterTransactionNMSWP(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetReservationPaymentDetailAfterTransactionNMSWP(objBel);
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

        public DataSet GetOutstandingDuesAmountNMSWP(string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetOutstandingDuesAmountNMSWP(serviceID);
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
        public DataSet GetAllotteeRecordToBindDuesPayment(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotteeRecordToBindDuesPayment(objBel);
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
        public DataSet GetReservationPaymentDetailAfterTransaction(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetReservationPaymentDetailAfterTransaction(objBel);
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

        public DataSet GetOutstandingDuesPaymentDetailAfterTransaction(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetOutstandingDuesPaymentDetailAfterTransaction(objBel);
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

        public DataSet GetOutstandingDuesAmount(string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetOutstandingDuesAmount(serviceID);
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

        public DataSet GetReservationAmount(string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetReservationAmount(serviceID);
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

        public DataSet GetDetailsWithReservationMoney(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try

            {

                return objDal.GetDetailsWithReservationMoney(objBel);

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

        public DataSet GetAllotteeRecordToBind(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotteeRecordToBind(objBel);
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

        #endregion

        #region "Road and Park Master"

        public Int32 DeleteRoadFromMaster(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteRoadFromMaster(objBel);
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

        public DataSet BindlistRoadInListbox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindlistRoadInListbox(objBel);
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


        public Int32 RoadEntryInRoadMasterNew(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.RoadEntryInRoadMasterNew(objBel);
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

        public Int32 DeleteParkFromMaster(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteParkFromMaster(objBel);
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


        public Int32 ParkEntryInParkMasterNew(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ParkEntryInParkMasterNew(objBel);
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


        public DataSet BindlstParksInListbox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindlstParksInListbox(objBel);
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


        #endregion

        #region AllotteeMaster


        public DataSet GetPollutionCategoryBinding()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPollutionCategoryBinding();
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



        public Int32 DeleteAllotteeRecords(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteAllotteeRecords(objBel);
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

        public DataSet GetPlotArea(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPlotArea(objBel);
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

        public DataSet GetListOfAllotteedGISPlotsIAWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfAllotteedGISPlotsIAWise(objBel);
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
        public DataSet DuesPaymentRecivedEntry(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DuesPaymentRecivedEntry(objBel);
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

        public DataSet DuesEntry(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeuesEntry(objBel);
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

        public Int32 DuesPaymentDetailEntry(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DuesPaymentDetailEntry(objBel);
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

        public Int32 InsertInstallmentPaymentDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertInstallmentPaymentDetails(objBel);
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


        public DataSet GetPaymentDetailswithAmount(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPaymentDetailswithAmount(objBel);
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

        public Int32 DemandNoteDetailEntry(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DemandNoteDetailEntry(objBel);
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

        public DataSet GetAdjustedPaymentAgainstdDemand(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAdjustedPaymentAgainstdDemand(objBel);
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

        public Int32 UpdateInstallmentStatus(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateInstallmentStatus(objBel);
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

        public DataSet GetPaymentRecivedwithAmount(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPaymentRecivedwithAmount(objBel);
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

        #endregion


        #region UploadAllDocument

        public Int32 UploadAllDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadAllDocument(objBel);
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

        #endregion


        #region PlotNumberUpdate

        public DataSet GetAllAllotteeDetailsforupdateplotID(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllAllotteeDetailsforupdateplotID(objBel);
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
        #endregion
        #region AllotteeMasterPlotNumberUpdate

        public Int32 PlotEntryInAllotteeMaster(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.PlotEntryInAllotteeMaster(objBel);
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

        public DataSet GetRegionalOfficeALLRecords()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetRegionalOfficeALLRecords();
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
        #endregion

        #region BuildingPlanAccountDetails

        public DataSet GetListOfBuildingPlanAccountDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfBuildingPlanAccountDetails(objBel);
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

        public DataSet GetListOfBuildingPlanAccountDetailsCleared(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfBuildingPlanAccountDetailsCleared(objBel);
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

        public Int32 UpdateApplicationAfterAccountClearenceBP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicationAfterAccountClearenceBP(objBel);
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
        #endregion


        #region LandAllotmentReports

        public DataSet GetTracingDocView(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetTracingDocView(objBel);
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
        public Int32 UploadTracing(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadTracing(objBel);
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
        public Int32 UploadJointCertificate(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadJointCertificate(objBel);
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

        public DataSet CheckTracingDoc(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.CheckTracingDoc(objBel);
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
        public DataSet GetLandAllotmentReports(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetLandAllotmentReports(objBel);
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
        #endregion


        #region HDFCPayment

        public DataSet GetBuildingPlanChargesRevised(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBuildingPlanChargesRevised(objBel);
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
        public string UpdateHDFCAllotteTransaction(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateHDFCAllotteTransaction(objBel);
            }
            catch
            {
                return "Failed";
            }
            finally
            {
                objDal = null;
            }
        }

        #endregion


        #region "Nivesh Mitra Flow"

        public Int32 UpdateEmailFromNiveshMitra(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateEmailFromNiveshMitra(objBel);
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

        public Int32 UploadCommitteeMinutes(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadCommitteeMinutes(objBel);
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
        public Int32 UploadHeadOfficeCommitteeMinutes(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadHeadOfficeCommitteeMinutes(objBel);
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
        public Int32 UploadCoverLetter(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadCoverLetter(objBel);
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

        public DataSet GetBuildingPlanCharges(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBuildingPlanCharges(objBel);
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
        public DataSet GetBuildingPlanChargesReceived(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBuildingPlanChargesReceived(objBel);
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

        public DataSet GetProcessingForNiveshMitraBuildingPlan(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetProcessingForNiveshMitraBuildingPlan(objBel);
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

        public DataSet GetapplicableFormFeeforAllotment(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableFormFeeforAllotment(objBel);
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



        public Int32 UpdateFeePaidStatus(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateFeePaidStatus(objBel);
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


        public DataSet GetapplicableChargesnDataforAllotmentInternal(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesnDataforAllotmentInternal(objBel);
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
        public DataSet GetapplicableChargesnDataNew(string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesnDataNew(serviceID);
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

        #endregion




        #region ProcessSimplification


        public DataSet GetApplicationOfBuildingPlanRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfBuildingPlanRejected(objBel);
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
        //GetApplicationAmalgamationRejected
        public DataSet GetApplicationAmalgamationRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationAmalgamationRejected(objBel);
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

        public DataSet GetApplicationTransferRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationTransferRejected(objBel);
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


        public DataSet GetApplicationOfBuildingPlanUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfBuildingPlanUnderProcess(objBel);
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
        public DataSet GetApplicationOfLidaBuildingPlanUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLidaBuildingPlanUnderProcess(objBel);
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

        public DataSet GetApplicationOfBuildingPlanUnderObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfBuildingPlanUnderObjection(objBel);
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

        //Amalgamation UnderObjection
        public DataSet GetApplicationOfAmalgamationUnderObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfAmalgamationUnderObjection(objBel);
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

        public DataSet GetApplicationOfTransferUnderObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfTransferUnderObjection(objBel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }//GetApplicationOfLidaBuildingPlanRejected
        public DataSet GetApplicationOfLidaBuildingPlanCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLidaBuildingPlanCompleted(objBel);
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
        public DataSet GetApplicationOfLidaBuildingPlanRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLidaBuildingPlanRejected(objBel);
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
        public DataSet GetApplicationOfLidaBuildingPlanUnderObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLidaBuildingPlanUnderObjection(objBel);
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

        public DataSet GetApplicationOfBuildingPlanCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfBuildingPlanCompleted(objBel);
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
        public DataSet GetApplicationOfTransferPlotCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfTransferPlotCompleted(objBel);
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
        public DataSet GetApplicationOfTransferPlotUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfTransferPlotUnderProcess(objBel);
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
        public DataSet GetApplicationOfBuildingPlanInBox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfBuildingPlanInBox(objBel);
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
        //--Test
        public DataSet GetApplicationOfLidaBuildingPlanInBox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLidaBuildingPlanInBox(objBel);
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
        public DataSet GetApplicationOfLidaBuildingPlanNotApprovedInBox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfLidaBuildingPlanNotApprovedInBox(objBel);
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
        public DataSet GetApplicationOfTransferPlotInBox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationOfTransferPlotInBox(objBel);
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


        public DataSet Get_Notesheet_of_applicationBT(string ServiceReqNo)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.Get_Notesheet_of_applicationBT(ServiceReqNo);
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
        public DataSet Get_Notesheet_of_LidaapplicationBTApproved(string ServiceReqNo)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.Get_Notesheet_of_LidaapplicationBTApproved(ServiceReqNo);
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
        public Int32 TransferApplicationBT(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.TransferApplicationBT(objBel);
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
        public Int32 TransferApplicationLida(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.TransferApplicationLida(objBel);
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


        public Int32 ClearRejectionReasons(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearRejectionReasons(objBel);
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

        public Int32 SaveAllotmentRejectionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveAllotmentRejectionDetails(objBel);
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


        public Int32 TransferApplication(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.TransferApplication(objBel);
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

        public DataSet Get_Notesheet_of_application(string ServiceReqNo)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.Get_Notesheet_of_application(ServiceReqNo);
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

        public DataSet GetTypeoFIndustry()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetTypeoFIndustry();
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
        public DataSet GetIACategory()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetIACategory();
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

        public Int32 SaveTempServiceChecklistDocumentResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTempServiceChecklistDocumentResubmit(objBel);
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

        public Int32 UpdateApplicantProjectDetailsResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantProjectDetailsResubmit(objBel);
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
        public Int32 UpdateApplicantAccountsDetailsResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantAccountsDetailsResubmit(objBel);
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

        public Int32 SaveApplicantImageResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantImageResubmit(objBel);
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

        public Int32 SaveApplicantSignResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantSignResubmit(objBel);
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

        public DataSet UpdateApplicantDetailsResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantDetailsResubmit(objBel);
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

        public Int32 ClearShareHolderResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearShareHolderResubmit(objBel);
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

        public Int32 SaveShareHolderDetailsResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveShareHolderDetailsResubmit(objBel);
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

        public Int32 SaveDirectorsDetailsResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveDirectorsDetailsResubmit(objBel);
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

        public Int32 SaveTrusteeDetailsResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTrusteeDetailsResubmit(objBel);
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
        public Int32 SavePatnersDetailsResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SavePatnersDetailsResubmit(objBel);
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

        public Int32 FinalSResubmission(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.FinalSResubmission(objBel);
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
        public Int32 SaveObjectionResponse(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveObjectionResponse(objBel);
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
        public DataSet GetevaluationDataIndividual(String ServiceReqNo)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetevaluationDataIndividual(ServiceReqNo);
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

        public DataSet BindEvaluationChecklistGridIndividual(string ServiceReqNo)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.BindEvaluationChecklistGridIndividual(ServiceReqNo);
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
        public DataSet GetApplicationUnderProcess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationUnderProcess(objBel);
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
        public DataSet GetApplicationUnderProcessHO(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationUnderProcessHO(objBel);
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
        public DataSet GetApplicationRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationRejected(objBel);
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


        public DataSet GetApplicationCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationCompleted(objBel);
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
        public DataSet GetLidaBPNotApprovedCompleted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetLidaBPNotApprovedCompleted(objBel);
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
        public DataSet GetLidaBPNotApprovedRejected(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetLidaBPNotApprovedRejected(objBel);//GetLidaBPNotApprovedRejected
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
        public DataSet GetLidaBPNotApprovedUnderObjection(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetLidaBPNotApprovedUnderObjection(objBel);//GetLidaBPNotApprovedUnderObjection
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

        public DataSet GetApplicationForClarfication(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetApplicationForClarfication(objBel);
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


        public DataSet Get_Announcement_ListNew_HO(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Get_Announcement_ListNew_HO(objBel);
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
        public DataSet Get_Announcement_ListNew(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Get_Announcement_ListNew(objBel);
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

        public DataSet GETDATAFORCMDASHBOARDREPORT(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GETDATAFORCMDASHBOARDREPORT(objBel);
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



        #endregion


        





        #region   IndustrialAreaMaster

        public DataSet GetdistictRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetdistictRecords(objBel);
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

        public Int32 IndustrialAreaEntryMaster(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.IndustrialAreaEntryMaster(objBel);
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
        public Int32 DeleteIndustrialAreaMaster(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteIndustrialAreaMaster(objBel);
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

        public DataSet GetpollutionCategory(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetpollutionCategory(objBel);
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
        public DataSet GetIndustrialAreaRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIndustrialAreaRecords(objBel);
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
        public DataSet GetregionalOfficeList(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetregionalOfficeList(objBel);
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
        public DataSet GetIndustrialAreaStatus()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIndustrialAreaStatus();
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

        #endregion



        #region PlotMasterNew

        public DataSet GetPlotStatusNew()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPlotStatusNew();
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

        public DataSet GetIANew(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIANew(objBel);
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

        public DataSet BindlstPlotsInListbox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindlstPlotsInListbox(objBel);
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

        public DataSet GetSectorsIAWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetSectorsIAWise(objBel);
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

        public DataSet GetAllLandBank(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllLandBank(objBel);
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
        public Int32 PlotEntryInPlotMasterNew(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.PlotEntryInPlotMasterNew(objBel);
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

        public Int32 DeletePlotInPlotMaster(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeletePlotInPlotMaster(objBel);
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

        public DataSet GetIALandLimits(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIALandLimits(objBel);
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

        public DataSet GetPlotcategoryLandUseWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPlotcategoryLandUseWise(objBel);
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

        #endregion



        #region Track Application

        public DataSet GetTrackApplicationList(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetTrackApplicationList(objBel);
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

        public Int32 UpdateTrackApplication(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateTrackApplication(objBel);
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

        public Int32 TrackapplicationRM(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.TrackapplicationRM(objBel);
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
        #endregion
        public DataSet GetAllotteeApplicationRequestTempRecords(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeApplicationRequestTempRecords(objBel);
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
        public DataSet TrackDetails(belBookDetails objBel)

        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try

            {

                return objDal.TrackDetails(objBel);

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

        public DataSet GetListOfAllotteedPlotsIAWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfAllotteedPlotsIAWise(objBel);
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

        public DataSet GetDetailsWithDemand(belBookDetails objBel)

        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try

            {

                return objDal.GetDetailsWithDemand(objBel);

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

        public DataSet GetDemandPayAmount(string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetDemandPayAmount(serviceID);
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


        public DataSet GetDemandPaymentDetailAfterTransaction(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetDemandPaymentDetailAfterTransaction(objBel);
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

        public DataSet CheckControlIdAlreadyExist(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.CheckControlIdAlreadyExist(objBel);
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


        public DataSet Get_Announcement_List(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Get_Announcement_List(objBel);
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

        #region Account

        public DataSet GetLandAllottementCompletedRecords(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetLandAllottementCompletedRecords(objBel);
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

        public DataSet GetListOfApplicationHOLevel(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfApplicationHOLevel(objBel);
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
        public DataSet GetListOfApplication(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfApplication(objBel);
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
        public DataSet GetListOfApplicationForAccountClearanceGSTRepots(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfApplicationForAccountClearanceGSTRepots(objBel);
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
        public DataSet GetListOfApplicationForAccountClearanceRepots(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfApplicationForAccountClearanceRepots(objBel);
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
        public DataSet GetBifircatedPayment(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBifircatedPayment(objBel);
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
        #endregion

        #region   AllotteeApplication
        public Int32 SaveApplicationForm(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicationForm(objBel);
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
        public DataSet GetListOfVacantPlotsIAWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfVacantPlotsIAWise(objBel);
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

        public DataSet GetapplicableChargesnDataforAllotment(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesnDataforAllotment(objBel);
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

        public DataSet ApplicationLandAllotmentInHouse(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ApplicationLandAllotmentInHouse(objBel);
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


        public DataSet ApplicationLandAllotmentNiveshMitra(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ApplicationLandAllotmentNiveshMitra(objBel);
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

        public DataSet GetCompanyType()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetCompanyType();

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

        public DataSet GetPriorityCategory()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetPriorityCategory();
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

        public DataSet GetAllServiceChecklists(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllServiceChecklists(objBel);
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

        public Int32 SaveServiceChecklistDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveServiceChecklistDocument(objBel);
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

        public DataSet GetIAContact(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIAContact(objBel);
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
        public Int32 SaveApplicantImage(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantImage(objBel);
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

        public DataSet CheckIARatesExistOrNot(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.CheckIARatesExistOrNot(objBel);
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


        public DataSet GetLAApplicantDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetLAApplicantDetails(objBel);
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

        public DataSet GetNewApplicantDetails(belBookDetails objBel)

        {


            BooksDetails_DAL objDal = new BooksDetails_DAL();


            try

            {

                return objDal.GetNewApplicantDetails(objBel);

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

        public DataSet GetNewApplicantDetailsInternal(belBookDetails objBel)

        {


            BooksDetails_DAL objDal = new BooksDetails_DAL();


            try

            {

                return objDal.GetNewApplicantDetailsInternal(objBel);

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

        public DataSet GetTempReqIDFromMain(belBookDetails objBel)

        {


            BooksDetails_DAL objDal = new BooksDetails_DAL();


            try

            {

                return objDal.GetTempReqIDFromMain(objBel);

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

        public DataSet GetTempReqIDFromMainID(belBookDetails objBel)

        {


            BooksDetails_DAL objDal = new BooksDetails_DAL();


            try

            {

                return objDal.GetTempReqIDFromMainID(objBel);

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
        
        public DataSet GetCheckAllotmentNo(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try

            {

                return objDal.GetCheckAllotmentNo(objBel);

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

        
        public Int32 UpdateAllotteeMassterAID(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateAllotteeMassterAID(objBel);
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
        public DataSet GetTransactionDetailsByServiceReqNo(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try

            {

                return objDal.GetTransactionDetailsByServiceReqNo(objBel);

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

        public DataSet UpdateApplicantDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantDetails(objBel);
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


        public Int32 ClearShareHolder(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearShareHolder(objBel);
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
        public Int32 UpdateURN(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateURN(objBel);
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


        public Int32 SaveShareHolderDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveShareHolderDetails(objBel);
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
        public Int32 ChangeStatusSWP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ChangeStatusSWP(objBel);
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


        public Int32 SaveDirectorsDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveDirectorsDetails(objBel);
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

        public Int32 SaveTrusteeDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTrusteeDetails(objBel);
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

        public Int32 SavePatnersDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SavePartnerDetails(objBel);
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

        public Int32 UpdateApplicantProjectDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantProjectDetails(objBel);
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
        public Int32 UpdateApplicantAccountsDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantAccountsDetails(objBel);
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

        #endregion

        #region Evaluation


        public DataSet GetBPBylawsByArea(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBPBylawsByArea(objBel);
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

        public Int32 Set_ServiceTicketChecklistBP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.Set_ServiceTicketChecklistBP(objBel);
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

        public Int32 SetAccountClearenceRecords(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {

                return objDal.SetAccountClearenceRecords(objBel);
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

        public DataSet Get_Notesheet_of_service(int PacketId)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.Get_Notesheet_of_service(PacketId);
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
        public DataSet GetevaluationData(int PacketId)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetevaluationData(PacketId);
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


        public DataSet BindEvaluationChecklistGrid(int PacketId)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.BindEvaluationChecklistGrid(PacketId);
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



        public DataSet GetcommitteeforAllotmentApproval(int PacketId)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetcommitteeforAllotmentApproval(PacketId);
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

        public DataSet BindTicketGridView(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.BindTicketGridView(objBel);
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

        public string ServiceTicketCreationforaAllotment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ServiceTicketCreationforaAllotment(objBel);
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

        public DataSet BindGridInprocess(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindGridInprocess(objBel);
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

        public Int32 ServicePacketCreationforaAllotment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ServicePacketCreationforaAllotment(objBel);
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


        public DataSet GetapplicableChargesnDataAC(string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesnDataAC(serviceID);
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


        public DataSet GetapplicableChargesnData(string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableChargesnData(serviceID);
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

        public DataSet GetPaymentDetailTransactionWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPaymentDetailTransactionWise(objBel);
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




        public DataSet GetApplicableFeesFromTransaction(string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetApplicableFeesFromTransaction(serviceID);
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



        public string UpdateAllotteTransaction(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateAllotteTransaction(objBel);
            }
            catch
            {
                return "Failed";
            }
            finally
            {
                objDal = null;
            }
        }


        public DataSet GetServiceAccountClearenceRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetServiceAccountClearenceRecords(objBel);
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




        public DataSet GetServiceTicketTags()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetServiceTicketTags();
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
        #endregion
        #region plot Bank
        public Int32 AdvertisePlots(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.AdvertisePlots(objBel);
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
        public Int32 CancelPlots(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.CancelPlots(objBel);
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

        public DataSet BindlstPlotsListbox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindlstPlotsListbox(objBel);
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
        public DataSet BindlstPlotsListboxSearch(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindlstPlotsListboxSearch(objBel);
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
        public DataSet PlotBankAvailableForAllotment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.PlotBankAvailableForAllotment(objBel);
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


        public DataSet PlotsForCancelation(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.PlotsForCancelation(objBel);
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


        public DataSet GetIndustrialAreaDetailsHODashboard()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetIndustrialAreaDetailsHODashboard();
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



        public Int32 PlotEntryInPlotMaster(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.PlotEntryInPlotMaster(objBel);
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
        public Int32 DeletePlotPlotMaster(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeletePlotPlotMaster(objBel);
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
        public DataSet GetPlotSubStatus(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPlotSubStatus(objBel);
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
        public DataSet GetPlotStatus()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPlotStatus();
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
        public DataSet BindCancelledPlotsListbox(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.BindCancelledPlotsListbox(objBel);
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
        public DataSet GroundForCancelation(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GroundForCancelation(objBel);
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



        public DataSet GetDefaultersList(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetDefaultersList(objBel);
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
        #endregion

        #region "LegalCaseType"

        public Int32 DeleteCaseListDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteCaseListDocument(objBel);
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


        public DataSet GetlJurisdictionListBinding()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetlJurisdictionListBinding();
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
        public DataSet GetlegalcaseType()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetlegalcaseType();
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

        public DataSet GetAlloteeID(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAlloteeID(objBel);
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

        public DataSet GetLegalCasehistoryMaster(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetLegalCasehistoryMaster(objBel);
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

        public DataSet GetPlotDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPlotDetails(objBel);
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
        public Int32 SaveCaseDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveCaseDocument(objBel);
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

        public DataSet GetcaseID()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetcaseID();
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

        public Int32 SaveCaseDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveCaseDetail(objBel);
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

        public Int32 SaveNewCaseDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveNewCaseDetail(objBel);
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
        public DataSet GetLegalAllCasehistory(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetLegalAllCasehistory(objBel);
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
        public DataSet GetLegalCasehistory(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetLegalCasehistory(objBel);
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

        public DataSet GetlegalhistoryDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetlegalhistoryDocument(objBel);
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
        public Int32 DeleteLegalhistoryCaseWise(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteLegalhistoryCaseWise(objBel);
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


        public DataSet GetCaselistsDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetCaselistsDocument(objBel);
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

        public DataSet GetCasehistoryDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetCasehistoryDocument(objBel);
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

        public DataSet GetCaseListDocuments(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCheckListDocuments(objBel);
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
        #endregion

        #region "New_UpcomingIndustrial"

        public DataSet GetVacentPlotDetailForCM(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetVacentPlotDetailForCM(objBel);
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
        public DataSet GetProductionNotStarted(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetProductionNotStarted(objBel);
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
        public DataSet GetSickUnits(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetSickUnits(objBel);
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




        public DataSet GetCM_REPORTS(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetCM_REPORTS(objBel);
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



        public DataSet GetPreCM_New_UpcomingIndustrialDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPreCM_New_UpcomingIndustrialDetail(objBel);
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
        public DataSet GetCM_New_UpcomingIndustrialDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetCM_New_UpcomingIndustrialDetail(objBel);
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
        public Int32 SaveCM_New_UpcomingIndustrialDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveCM_New_UpcomingIndustrialDetail(objBel);
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
        public Int32 UpdateCM_New_UpcomingIndustrialDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateCM_New_UpcomingIndustrialDetail(objBel);
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
        public Int32 DeleteCM_New_UpcomingIndustrialDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteCM_New_UpcomingIndustrialDetail(objBel);
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

        #endregion

        public DataSet CM_GetLoginDetailCheck(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.CM_GetLoginDetailCheck(objBel);
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


        public Int32 CM_UpdatePassword(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.CM_UpdatePassword(objBel);
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



        #region "VacantPlots"
        public DataSet GetCM_PreVacentPlot(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCM_PreVacentPlot(objBel);
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

        public DataSet GetCM_VacentPlotDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetCM_VacentPlotDetail(objBel);
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
        public Int32 SaveCM_VacentPlotDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveCM_VacentPlotDetail(objBel);
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
        public Int32 UpdateCM_VacentPlotDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateCM_VacentPlotDetail(objBel);
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
        public Int32 DeleteCM_VacentPlotDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteCM_VacentPlotDetail(objBel);
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

        #endregion
        #region "ProductionDetail"
        public DataSet GetCM_PreProductionDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCM_PreProductionDetail(objBel);
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
        public DataSet GetCM_ProductionDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetCM_ProductionDetail(objBel);
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
        public Int32 SaveCM_ProductionDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveCM_ProductionDetail(objBel);
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
        public Int32 UpdateCM_ProductionDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateCM_ProductionDetail(objBel);
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
        public Int32 DeleteCM_ProductionDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteCM_ProductionDetail(objBel);
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

        #endregion
        #region CM
        public Int32 CM_CheckLogin(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {

                return objDal.CM_CheckLogin(objBel);
            }
            catch (Exception ex)
            {

                throw ex;

            }
            //finally
            //{

            //    objDal = null;
            //}
        }
        public DataSet GetCMUserCompany(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetCMUserCompany(objBel);
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
        public DataSet GetCMregionalNameRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCMregionalNameRecords(objBel);
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
        public DataSet GetCM_RegionNameIndustrialDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCM_RegionNameIndustrialDetail(objBel);
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
        #endregion
        #region "SickUnitsDetail"
        public DataSet GetPreCM_SickUnitsDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCM_PreSickUnitsDetail(objBel);
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
        public DataSet GetCM_SickUnitsDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetCM_SickUnitsDetail(objBel);
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
        public Int32 SaveCM_SickUnitsDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveCM_SickUnitsDetail(objBel);
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
        public Int32 UpdateCM_SickUnitsDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateCM_SickUnitsDetail(objBel);
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
        public Int32 DeleteCM_SickUnitsDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteCM_SickUnitsDetail(objBel);
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

        #endregion

        #region "Engineering"

        public Int32 InsertEngineeringDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertEngineeringDetail(objBel);
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
        public Int32 UpdateEngineeringDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateEngineeringDetail(objBel);
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
        public Int32 DeleteEngineeringDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteEngineeringDetail(objBel);
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
        public DataSet GetEngineeringDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetEngineeringDetail(objBel);
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
        public DataSet GetIndustrialAreaEngineeringDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetIndustrialAreaEngineeringDetail(objBel);
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
        public DataSet GetConstructionDivisionsRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetConstructionDivisionsRecords(objBel);
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
        public DataSet GetIndustrialAreaCDDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIndustrialAreaCDDetail(objBel);
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
        #endregion




        #region "lastupdated"

        public DataSet GetIndustrialAreaDetailRegWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIndustrialAreaDetailRegWise(objBel);
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


        public DataSet GetRegionalOffice(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetRegionalOffice(objBel);
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

        public DataSet SearchInternalUser(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.SearchInternalUser(objBel);
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


        public DataSet GetIALeaseRateSearchDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetIALeaseRateSearchDetails(objBel);
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



        public DataSet GetIATransferLevySearchDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetIATransferLevySearchDetail(objBel);
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




        public DataSet GetRegionalOfficeParam(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetRegionalOfficeParam(objBel);
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



        public DataSet GetRegionalOfficeAll()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetRegionalOfficeAll();
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


        public DataSet GetIAUserRoleWise(string IA)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIAUserRoleWise(IA);
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


        public DataSet GetUserRole(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetUserRole(objBel);
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



        public Int32 InsertIALeaseRate(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertIALeaseRate(objBel);
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


        public DataSet GetIAMaintenanceChargeDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIAMaintenanceChargeDetails(objBel);
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


        public Int32 DeleteIAMaintenanceCharge(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteIAMaintenanceCharge(objBel);
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


        public DataSet GetIAMaintenanceChargePrev(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIAMaintenanceChargePrev(objBel);
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



        public DataSet GetIALeaseRateDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIALeaseRateDetails(objBel);
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





        public Int32 DeleteIALeaseRate(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteIALeaseRate(objBel);
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



        public DataSet GetIALeaseRatePrev(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIALeaseRatePrev(objBel);
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



        public DataSet GetIAMinPeriodLease(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIAMinPeriodLease(objBel);
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




        public Int32 InsertTransferLevyPer(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertTransferLevyPer(objBel);
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



        public DataSet GetTransferLevyPerDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetTransferLevyPerDetails(objBel);
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


        public DataSet GetTimeExtensionPerDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetTimeExtensionPerDetails(objBel);
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

        public Int32 DeleteIATimeExtension(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteIATimeExtension(objBel);
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

        public Int32 DeleteIATransferLevy(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteIATransferLevy(objBel);
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


        public DataSet GetIATimeExtensionPrev(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIATimeExtensionPrev(objBel);
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

        public DataSet GetIATransferLevyPrev(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIATransferLevyPrev(objBel);
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


        public DataSet GetIAMinPeriodTransferLevy(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIAMinPeriodTransferLevy(objBel);
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














        #endregion



















        #region "LandAcquistionDetail"

        public Int32 SaveLandAcquistionDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveLandAcquistionDetail(objBel);
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
        public Int32 UpdateLandAcquistionDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateLandAcquistionDetail(objBel);
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
        public Int32 DeleteLandAcquistionDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteLandAcquistionDetail(objBel);
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
        public DataSet GetLandAcquistionDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetLandAcquistionDetail(objBel);
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
        public DataSet GetGetUserRoleDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetGetUserRoleDetail(objBel);
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
        public DataSet GetIndustrialAreaDetailforLandAcquist()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIndustrialAreaDetailforLandAcquist();
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
        #endregion

        #region "Digitization"

        public DataSet GetDigitizationDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetDigitizationDetail(objBel);
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
        public Int32 SaveDigitizationDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveDigitizationDetail(objBel);
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
        public Int32 UpdateDigitizationDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateDigitizationDetail(objBel);
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

        public Int32 DeleteDigitizationDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteDigitizationDetail(objBel);
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
        #endregion




        public DataSet GetNivishMitraBasicDetail(string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetNivishMitraBasicDetail(serviceID);
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
        //public DataSet GetapplicableChargesnData(string serviceID)
        //{

        //    BooksDetails_DAL objDal = new BooksDetails_DAL();

        //    try
        //    {
        //        return objDal.GetapplicableChargesnData(serviceID);
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



        //public DataSet GetApplicableFeesFromTransaction(string serviceID)
        //{

        //    BooksDetails_DAL objDal = new BooksDetails_DAL();

        //    try
        //    {
        //        return objDal.GetApplicableFeesFromTransaction(serviceID);
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



        //public string UpdateAllotteTransaction(belBookDetails objBel)
        //{
        //    BooksDetails_DAL objDal = new BooksDetails_DAL();
        //    try
        //    {
        //        return objDal.UpdateAllotteTransaction(objBel);
        //    }
        //    catch
        //    {
        //        return "Failed";
        //    }
        //    finally
        //    {
        //        objDal = null;
        //    }
        //}



        #region "van vibhag"


        public DataSet GetBindVanVibhagMasterGridView(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetBindVanVibhagMasterGridView(objBel);
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




        public DataSet GetBindVanVibhagGridView(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetBindVanVibhagGridView(objBel);
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




        public Int32 SaveVanVibhagDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveVanVibhagDetail(objBel);
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



        public Int32 UpdateVanVibhagDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateVanVibhagDetails(objBel);
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



        public Int32 DeleteVanVibhaagDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteVanVibhaagDetail(objBel);
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





        public DataSet GetPlatationDocument(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPlatationDocument(objBel);
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













        #endregion


        #region "Save Allottee Records"

        public Int32 InsertUpdateAllotteeDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertUpdateAllotteeDetails(objBel);
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



        public Int32 InsertUpdateAllottee_tblPaymentHeader(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertUpdateAllottee_tblPaymentHeader(objBel);
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




        public Int32 InsertUpdate_MasterInvestment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertUpdate_MasterInvestment(objBel);
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



        public Int32 InsertUpdateAllottee_tblPaymentDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertUpdateAllottee_tblPaymentDetail(objBel);
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





        public DataSet InsertUpdateAllotteeDetails_step1(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertUpdateAllotteeDetails_step1(objBel);
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

        public DataSet GetAlloteeDetailwithAID(string AID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAlloteeDetailwithAID(AID);
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

        public DataSet GetAllotmentNoDetail(string AllotmentNo)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotmentNoDetail(AllotmentNo);
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
        public DataSet GetNewAlloteeDetailwithParameter(string IA)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetNewAlloteeDetailwithParameter(IA);
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




        public DataSet GetapplicableMasterByAllottee(string IA)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetapplicableMasterByAllottee(IA);
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


        public DataSet GetAllAllotteeDetailsFilledById(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllAllotteeDetailsFilledById(objBel);
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



        public DataSet GetServiceMasterChecklists(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetServiceMasterChecklists(objBel);
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



        public Int32 SaveServiceChecklist(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveServiceChecklist(objBel);
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

        public Int32 UpdateServiceChecklistDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateServiceChecklistDetails(objBel);
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



        public DataSet GetEmploymentData(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetEmploymentData(objBel);
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


        public DataSet GetInvestmentdata(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetInvestmentdata(objBel);
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


        public DataSet GetCMDashboard(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCMDashboard(objBel);
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




        public Int32 InsertUpdateAllotteeDetails_step2(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertUpdateAllotteeDetails_step2(objBel);
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


        public Int32 InsertNewAllotteeDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertNewAllotteeDetails(objBel);
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


        public Int32 SaveRequestReport(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveRequestReport(objBel);
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
        public Int32 SaveInspectionDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveInspectionDetails(objBel);
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
        public Int32 SaveBookDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveBookDetails(objBel);
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
        public Int32 SaveServiceTimelinesDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveServiceTimelinesDetails(objBel);
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

        public DataSet SetServiceRequest(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequest(objBel);
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

        public Int32 SetServiceRequestFinish(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetServiceRequestFinish(objBel);
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
        public Int32 SetBPResubmit(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetBPResubmit(objBel);
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








        public DataSet GetChecklistDocumentByParmeter(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetChecklistDocumentByParmeter(objBel);
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
        public DataSet GetCoverLetter(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCoverLetter(objBel);
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


        public DataSet GetHeadOfficeMinute(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetHeadOfficeMinute(objBel);
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

        public DataSet GetInspectionReport(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetInspectionReport(objBel);
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

        public DataSet GetCheckListDocument(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCheckListDocument(objBel);
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






        public Int32 DeleteCheckListDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteCheckListDocument(objBel);
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







        #endregion

        #region "Get  Allottee Records"
        public DataSet GetInspectionDetail()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetInspectionDetail();
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

        public DataSet GetAllotetmentLetterDocument(string par, string DocumentType)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotetmentLetterDocument(par, DocumentType);
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
        public DataSet GetAllotteeDocuments(string pa, string doctype)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetInspectionDetail();
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
        public DataSet GetAlloteeDocumentDetail(int par)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAlloteeDocumentDetail(par);
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
        public Int32 UpdateBuildingPlanDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateBuildingPlanDocument(objBel);
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



        public Int32 UpdateInspectionDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateInspectionDocument(objBel);
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


        public DataSet GetBuildingPlanDocumentDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBuildingPlanDocumentDetail(objBel);
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





        public DataSet GetAllotteesDocumenttBasedtooPar(int par, int id)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotteesDocumenttBasedtooPar(par, id);
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

        public Int32 UpdateAllotmentLetterDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateAllotmentLetterDocument(objBel);
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


        public DataSet GetBuildingPlanDocumentDetailBasedtooPar(int par, int id)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBuildingPlanDocumentDetailBasedtooPar(par, id);
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

        public DataSet GetExecutiveauthority(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetExecutiveauthority(objBel);
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


        public DataSet GetInspectionDocumentDetailBasedtooPar1(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetInspectionDocumentDetailBasedtooPar1(objBel);
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

        public DataSet GetInspectionDocumentDetailBasedtooPar(int par, int id)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetInspectionDocumentDetailBasedtooPar(par, id);
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

        public DataSet GetInspectionDocumentDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetInspectionDocumentDetail(objBel);
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

        public DataSet GetSearchRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();


            try
            {
                return objDal.GetSearchRecords(objBel);
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

        public DataSet GetUserRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();


            try
            {
                return objDal.GetUserRecords(objBel);
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

        public DataSet GetIAAssociatedWithRM(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetIAAssociatedWithRM(objBel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDal = null;
            }
        }



        public DataSet GetServiceRequestBPDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();


            try
            {
                return objDal.GetServiceRequestBPDetail(objBel);
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

        public DataSet GetAllotteeRecordComplete(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();


            try
            {
                return objDal.GetAllotteeRecordComplete(objBel);
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

        public DataSet GetBookRecords()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetBookRecords();
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

        public DataSet GetServiceTimelinesRecords()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetServiceTimelinesRecords();
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




        public DataSet GetInspectorRequestRecords(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetInspectorRequestRecords(objBel);
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




        public DataSet GetServiceRequestTempRecords(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetServiceRequestTempRecords(objBel);
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
        public DataSet GetInspectionCertificateBasedtoPar(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetInspectionCertificateBasedtoPar(objBel);
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

        public DataSet GetInspectionCertificateDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetInspectionCertificateDetail(objBel);
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

        public DataSet GetCheckListDocumentList(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetCheckListDocumentList(objBel);
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



        public DataSet GetServiceChecklists()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetServiceChecklists();
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
        #endregion

        #region "Delete Allottee Records"
        public Int32 DeleteBookRecord(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteBookRecord(objBel);
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
        public Int32 DeleteAllotteeRecord(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteAllotteeRecord(objBel);
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
        public Int32 DeleteServiceRecord(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteServiceTimeLinesRecord(objBel);
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

        public Int32 CheckLoginAllotte(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {

                return objDal.CheckLoginAllotte(objBel);
            }
            catch (Exception ex)
            {

                throw ex;

            }
            //finally
            //{

            //    objDal = null;
            //}
        }
        public Int32 CheckLogin(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {

                return objDal.CheckLogin(objBel);
            }
            catch (Exception ex)
            {

                throw ex;

            }
            //finally
            //{

            //    objDal = null;
            //}
        }


        //public Int32 CheckLoginLida(belBookDetails objBel)
        //{
        //    BooksDetails_DAL objDal = new BooksDetails_DAL();
        //    try
        //    {

        //        return objDal.CheckLoginLida(objBel);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;

        //    }
        //    //finally
        //    //{

        //    //    objDal = null;
        //    //}
        //}


        public DataSet GetServiceChecklists_SP_BY_Condtion(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetServiceChecklists_SP_BY_Condtion(objBel);
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
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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

        public DataSet GetServiceChecklistsPIP_SP_BY_Condtion(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetServiceChecklistsPIP_SP_BY_Condtion(objBel);
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


        public DataSet GetServiceChecklists(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetServiceChecklists(objBel);
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





        #endregion


        #region "Update Allottee Records"
        public Int32 UpdateBookRecord(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateBookRecord(objBel);
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
        public Int32 UpdateLeaseDeedFile(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateLeaseDeedFile(objBel);
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

        public Int32 UpdateInspectionFile(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateInspectionFile(objBel);
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

        public Int32 UpdateCompletionFile(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateCompletionFile(objBel);
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

        public Int32 UpdateOccupancyFile(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateOccupancyFile(objBel);
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
        public Int32 UpdateBuildingPlanFile(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateBuildingPlanFile(objBel);
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
        public Int32 UpdateAllotmentLetterFile(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateAllotmentLetterFile(objBel);
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
        public Int32 UpdateServiceTimelinesDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateServiceTimelinesRecord(objBel);
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

        public DataSet GetPayHeaderRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPayHeaderRecords(objBel);
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

        public DataSet GetregionalOfficeRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetregionalOfficeRecords(objBel);
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

        public DataSet GetBuildingPlanDetail()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBuildingPlanDetail();
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
        public DataSet GetApplicationType(string par)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetApplicationType(par);
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
        public DataSet GetInspectionDetailwithParameter(string IA)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetInspectionDetailwithParameter(IA);
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

        public DataSet GetBuildingPlanwithParameter(string IA)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBuildingPlanwithParameter(IA);
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

        public DataSet GetAlloteeDetailwithParameter(string IA)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAlloteeDetailwithParameter(IA);
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



        public DataSet GetAlloteeDetail()
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAlloteeDetail();
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
        public DataSet GetregionalNameRecords(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetregionalNameRecords(objBel);
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

        public DataSet GetregionalNameRecords1(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetregionalNameRecords1(objBel);
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

        public DataSet GetregionalNameRecordsAuc(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetregionalNameRecordsAuc(objBel);
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


        public DataSet GetIndustrialAreaDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIndustrialAreaDetail(objBel);
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



        public DataSet GetInternalUserPersonalDetails(string strName)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetInternalUserPersonalDetails(strName);
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



        #endregion

        public DataSet ViewSignedCopyLetter(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.ViewSignedCopyLetter(objBel);
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

        public Int32 UploadSignedCopyLetter(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadSignedCopyLetter(objBel);
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

        public Int32 DeleteSignedCopyLetter(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteSignedCopyLetter(objBel);
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

        public Int32 SaveArchitectDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveArchitectDetail(objBel);
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


        public DataSet GetAllotteesDocumentBasedtoPar(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotteesDocumentBasedtoPar(objBel);
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


        public DataSet GetAllotementLetterDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotementLetterDetail(objBel);
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


        public DataSet GetBuildingPlanCertificateDetail(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBuildingPlanCertificateDetail(objBel);
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


        public DataSet GetBuildingPlanCertificateDetailBasedtoPar(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBuildingPlanCertificateDetailBasedtoPar(objBel);
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

        public DataSet SetApplicationRequest(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetApplicationRequest(objBel);
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

        public DataSet GetBuildingPlanDocumentDetailBasedtooPar(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBuildingPlanDocumentDetailBasedtooPar(objBel);
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

        public Int32 SaveFARDetail(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveFARDetail(objBel);
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

        public DataSet GetAllotteeloginDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotteeloginDetails(objBel);
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


        public Int32 UpdateIsCompletedstatus(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateIsCompletedstatus(objBel);
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

        public DataSet GetServiceChecklists1(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetServiceChecklists1(objBel);
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



        public DataSet GetAllotteeDueAmount(string allotementLetterNo)
        {

            var objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllotteeDueAmount(allotementLetterNo);
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



        public DataSet GetLoginDetailCheck(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetLoginDetailCheck(objBel);
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
        


        public Int32 UpdatePassword(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdatePassword(objBel);
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

        public DataSet SetApplicationRequestService(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SetApplicationRequestService(objBel);
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


        public DataSet GetServiceRequestRecords(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetServiceRequestRecords(objBel);
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
        public Int32 ServiceTicketCreate(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ServiceTicketCreate(objBel);
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
        public DataSet getevaluationdataforBP(int IA, string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.getevaluationdataforBP(IA, serviceID);
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
        public DataSet GetevaluationData(int IA, string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetevaluationData(IA, serviceID);
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

        public DataSet GetDataStatus(string Case, string ServiceID, int IAID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetDataStatus(Case, ServiceID, IAID);
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

        public DataSet GetcommitteeforAllotmentApproval(string Case, string userID, int IAID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetcommitteeforAllotmentApproval(Case, userID, IAID);
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
        public DataSet GetApprovalOptionsandcommittee(string Case, string userID, int IAID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetApprovalOptionsandcommittee(Case, userID, IAID);
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
        public DataSet BindEvaluationChecklistGrid(int IA, string serviceID)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.BindEvaluationChecklistGrid(IA, serviceID);
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


        #region "PlotCancellation"

        public Int32 ClearPlotCancelNotices(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearPlotCancelNotices(objBel);
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


        public Int32 SavePlotNoticesDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SavePlotNoticesDetails(objBel);
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

        public Int32 SaveClauseNoticesDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveClauseNoticesDetails(objBel);
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



        #endregion



        #region "LixtOfNotices"
        public DataSet ListOfPlotForNotices(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ListOfPlotForNotices(objBel);
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

        public DataSet GetExistingAllotteeAgainstPlot(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetExistingAllotteeAgainstPlot(objBel);
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


        public DataSet GetAllotteeAgainstPlot(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeAgainstPlot(objBel);
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
        public DataSet GetListOfNotices(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetListOfNotices(objBel);
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

        public DataSet GetServicesForDropDown(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetServicesForDropDown(objBel);
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

        public Int32 InsertNoticesServed(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertNoticesServed(objBel);
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
        public Int32 UpdateNoticServedWithFile(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateNoticServedWithFile(objBel);
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
        public Int32 UpdateNoticServedWithoutFile(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateNoticServedWithoutFile(objBel);
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

        public Int32 DeleteNoticeServed(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteNoticeServed(objBel);
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


        public DataSet GetNoticesServedDoc(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetNoticesServedDoc(objBel);
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


        #endregion




        #region "Dues Clearence"



        public Int32 InsertDuesAgainstPlot(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertDuesAgainstPlot(objBel);
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

        public Int32 InsertPaymentAgainstPlot(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.InsertPaymentAgainstPlot(objBel);
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



        public DataSet GetDuesAndPayment(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetDuesAndPayment(objBel);
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

        public Int32 DeletePaymentAgainstPlot(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeletePaymentAgainstPlot(objBel);
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


        public Int32 DeleteDuesAgainstPlot(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteDuesAgainstPlot(objBel);
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


        #endregion




        #region "Allottee"

        public DataSet CheckFinalSubmission(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.CheckFinalSubmission(objBel);
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
        public DataSet GetListOfVacantPlotsForSubdivisionIAWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfVacantPlotsForSubdivisionIAWise(objBel);
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

        public DataSet GetPlotAdjacencyDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPlotAdjacencyDetails(objBel);
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

        public DataSet GetTempCheckListDocument(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetTempCheckListDocument(objBel);
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
        public Int32 SaveApplicantSign(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveApplicantSign(objBel);
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


        public Int32 SaveTempServiceChecklistDocument(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveTempServiceChecklistDocument(objBel);
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
        public Int32 MoveTemppplicationDataToMainTable(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.MoveTemppplicationDataToMainTable(objBel);
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

        #endregion


        #region "SmS"

        public DataSet GetPhoneNoOfUser(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetPhoneNoOfUser(objBel);
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


        public Int32 SaveOTP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveOTP(objBel);
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

        public DataSet VerifyOTP(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.VerifyOTP(objBel);
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


        #endregion



        #region "Account Clearance"

        public DataSet GetAllRegionalOffice(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetAllRegionalOffice(objBel);
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
        public DataSet GetIAregionalOfficeWise(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetIAregionalOfficeWise(objBel);
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

        public DataSet GetListOfApplicationForAccountClearance(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfApplicationForAccountClearance(objBel);
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
        public DataSet GetListOfApplicationAccountCleared(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfApplicationAccountCleared(objBel);
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

        public Int32 UpdateApplicationAfterAccountClearence(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicationAfterAccountClearence(objBel);
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


        #endregion

        #region "DemandNote"
        public DataSet GetAllotteeDetailsAgainstPlot(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetAllotteeDetailsAgainstPlot(objBel);
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

        public DataSet GetBifircatedDemandDetails(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetBifircatedDemandDetails(objBel);
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


        public Int32 DeleteDemandNote(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DeleteDemandNote(objBel);
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

        public DataSet DemandNoteEntry(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.DemandNoteEntry(objBel);
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


        //public Int32 DemandNoteDetailEntry(belBookDetails objBel)
        //{
        //    BooksDetails_DAL objDal = new BooksDetails_DAL();
        //    try
        //    {
        //        return objDal.DemandNoteDetailEntry(objBel);
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


        public Int32 UploadDemandNoticeDoc(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UploadDemandNoticeDoc(objBel);
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

        #endregion



        #region Devendra BLL

        public DataSet GetListOfInvestmentIAWisePIPReport(belBookDetails objBel)
        {

            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try
            {
                return objDal.GetListOfInvestmentIAWisePIPReports(objBel);
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

        #endregion



        #region MASHI BLL

        public DataSet GetPIPDetailsFin(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.GetPIPDetails(objBel);
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




        
        public DataSet GetCompanyTypeForPIPFin()
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();

            try

            {

                return objDal.GetCompanyTypeForPIPFin();

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

        public DataSet UpdateApplicantfIPBasicDetails(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.UpdateApplicantPIPBasicDetails(objBel);
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

        public Int32 ClearFirmConstitutionPIPFin(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.ClearFirmConstitutionPIPFin(objBel);
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


        public Int32 SaveShareHolderDetailsPIPFin(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
            try
            {
                return objDal.SaveShareHolderDetailsPIPFin(objBel);
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

        public Int32 SaveApplicantImagefIP(belBookDetails objBel)
        {
            BooksDetails_DAL objDal = new BooksDetails_DAL();
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





        #endregion
    }

    namespace encryptDecrypt
    {
        public class EncryptDecrypt
        {
            public static string encryptFile(string textToEncrypt, string key)
            {
                RijndaelManaged rijndaelCipher = new RijndaelManaged(); rijndaelCipher.Mode = CipherMode.ECB; rijndaelCipher.Padding = PaddingMode.PKCS7; rijndaelCipher.KeySize = 0x80; rijndaelCipher.BlockSize = 0x80; byte[] pwdBytes = Encoding.UTF8.GetBytes(key); byte[] keyBytes = new byte[0x10]; int len = pwdBytes.Length; if (len > keyBytes.Length)
                {
                    len = keyBytes.Length;
                }
                Array.Copy(pwdBytes, keyBytes, len); rijndaelCipher.Key = keyBytes; rijndaelCipher.IV = keyBytes; ICryptoTransform transform = rijndaelCipher.CreateEncryptor(); byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt); return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
            }
        }
    }
}