using BEL_Allotment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Allotment
{
    public class Mdal
    {//02Nov
        public Int32 Sp_SaveShareHoldersDetailPIPFIN(belBookDetails objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("[Sp_SaveShareHoldersDetailPIP]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApplicantId", objBEL.AllotteeID);
                cmd.Parameters.AddWithValue("@ShareholderName", objBEL.ShareHolderName);
                cmd.Parameters.AddWithValue("@Address", objBEL.Address);
                cmd.Parameters.AddWithValue("@SharePer", objBEL.SharePer);
                cmd.Parameters.AddWithValue("@Phone", objBEL.Phone);
                cmd.Parameters.AddWithValue("@Email", objBEL.Email);


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        //26
        public DataSet CheckIssueletter(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_CheckIssueletter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objBEL.ServiceRequestNO);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        //20
        public DataSet GetApplicationOfPIPFINObjection(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("GetApplicationForPIPFINObjection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objBEL.UserName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        public DataSet GetApplicationOfPIPFINApproved(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("GetApplicationForPIPFINApproved", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objBEL.UserName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        public DataSet GetApplicationForPIPFINUnderProcess(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("GetApplicationForPIPFINUnderProcess", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objBEL.UserName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        //17

        public DataSet BindTotalCountCompleted(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("GetAlertApplicationForPIPFIN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objBEL.UserName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        //11

        public Int32 SaveObjectionResponsePIP(belBookDetails objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("UploadObjectionResponsePIP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", objBEL.filename);
                cmd.Parameters.AddWithValue("@ContentType", objBEL.content);
                cmd.Parameters.AddWithValue("@DocPath", objBEL.LAWDocPath);
                cmd.Parameters.AddWithValue("@ServiceRequestNo", objBEL.ServiceRequestNO);
                cmd.Parameters.AddWithValue("@ApplicantResponse", objBEL.responseMessage);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public Int32 RaiseObjectionPIP(belBookDetails objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("[RaiseObjectionPIPFIN]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceReqNo", objBEL.ServiceRequestNO);
                cmd.Parameters.AddWithValue("@UserName", objBEL.UserName);
                cmd.Parameters.AddWithValue("@PIPReasonDetails", objBEL.PIPReasonDetails);
                cmd.Parameters.AddWithValue("@Clarification", objBEL.ObjectionDesc);
                cmd.Parameters.AddWithValue("@InternalObjDocName", objBEL.LAName);
                cmd.Parameters.AddWithValue("@InternalObjDocContent", objBEL.LAContentType);
                cmd.Parameters.AddWithValue("@UseDocPath", objBEL.LAWDocPath);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        //
        // 25 sep 2023
        public Int32 SaveDirectorsDetailsPIP(belBookDetails objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("[Sp_UpdateApplicantDirectorsPIP]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AllotteeID", objBEL.AllotteeID);
                cmd.Parameters.AddWithValue("@DirectorName", objBEL.DirectorName);
                cmd.Parameters.AddWithValue("@Address", objBEL.DirectorAddress);
                cmd.Parameters.AddWithValue("@DinPan", objBEL.DirectorDinPan);
                cmd.Parameters.AddWithValue("@Phone", objBEL.DirectorPhone);
                cmd.Parameters.AddWithValue("@Email", objBEL.DirectorEmail);


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public Int32 SaveDirectorsDetailsPIPFIN(Mpropertymodel objMpropertymodel)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("[Sp_UpdateApplicantDirectorsPIPFIN]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AllotteeID", objMpropertymodel.AllotteeID);
                cmd.Parameters.AddWithValue("@DirectorName", objMpropertymodel.DirectorName);
                cmd.Parameters.AddWithValue("@CategoryofDirectorship", objMpropertymodel.CategoryofDirectorship);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        // end code
        // 21 sep

        //public DataSet GetAlertApplicationOfPIPFINInBox(belBookDetails objBEL)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {//   GetAlertApplicationForPIPFINInbox
        //        SqlCommand cmd = new SqlCommand("GetAlertApplicationForPIPFIN", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@UserName", objBEL.UserName);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        adp.Fill(ds);
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        ds.Dispose();
        //    }
        //    return ds;
        //}

        public DataSet GetApplicationOfPIPFINRejected(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("GetApplicationForPIPFINRejected", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objBEL.UserName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        public DataSet GetApplicationOfPIPFINInBox(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[GetApplicationForPIPFINInbox]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", objBEL.UserName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        // end


        public Int32 FormFinalSubmissionPIP(belBookDetails objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("[sp_PIPFormFinalSubmission]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@KYCID", objBEL.KYCID);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public DataSet GetPIPCheckListDocument(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand("[GetPIP_AFACheckListDocumentDetails]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCheckListsID", objBEL.ServiceCheckListsID);
                cmd.Parameters.AddWithValue("@ServiceTimeLinesID", objBEL.ServiceTimeLinesID);
                //cmd.Parameters.AddWithValue("@Allotmentletterno", objBEL.UserName);
                cmd.Parameters.AddWithValue("@ServiceRequestNO", objBEL.ServiceRequestNO);
                cmd.Parameters.AddWithValue("@DocumentID", objBEL.DocumentID);


                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //    throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        public DataSet GetAllServiceChecklistsPIP(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {// old GetServiceChecklists_PIP_AFA 
                SqlCommand cmd = new SqlCommand("GetServiceChecklists_PIPAFA", con);

                cmd.Parameters.AddWithValue("@ServiceRequestNO", objBEL.ServiceRequestNO);
                cmd.Parameters.AddWithValue("@ServiceCondition", objBEL.ServiceChecklistCondition);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                ds.Clear();
                adp.Fill(ds);
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }


        public DataSet GetServiceChecklistsLAW_SP_BY_Condtion(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("GetServiceChecklistsPIPAFA_SP_BY_Condtion", con);
                cmd.Parameters.AddWithValue("@ServiceTimeLinesID", objBEL.ServiceChecklistId);


                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }

        public DataSet SavePIPFinDetails(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("InsertPIPFinRegistration_Sp1", con);
                cmd.CommandType = CommandType.StoredProcedure;
               

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", objBEL.ApplicantName);
                cmd.Parameters.AddWithValue("@MobileNo", objBEL.MobileNumber);
                cmd.Parameters.AddWithValue("@EmailID", objBEL.emailID);

                cmd.Parameters.AddWithValue("@ControlID", objBEL.MControlID);
                cmd.Parameters.AddWithValue("@UnitId", objBEL.MUnitId);

                cmd.Parameters.AddWithValue("@ServiceId", objBEL.MServiceId);
                cmd.Parameters.AddWithValue("@RequestID", objBEL.MRequestID);

                cmd.Parameters.AddWithValue("@CompanyName", "");
                cmd.Parameters.AddWithValue("@IndustrialArea", "");
                cmd.Parameters.AddWithValue("@ApplicationAdress1", "");
                cmd.Parameters.AddWithValue("@PanNo", "");

                


                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        public DataSet GetPIP_AFA_ProjectDetails(Mpropertymodel objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                
                SqlCommand cmd = new SqlCommand("sp_GetPIPAFADetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objBEL.ServiceRequestNO);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();

            }
            catch (Exception ex)
            {

                throw;

            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        // edi detail 
        public DataSet GetPIP_AFADetails(Mpropertymodel objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                //   usp_PIP_AFADetails
                SqlCommand cmd = new SqlCommand("sp_GetPIPAFADetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objBEL.ServiceRequestNO);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();

            }
            catch (Exception ex)
            {

                throw;

            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        // upload document
        public Int32 SavePIPServiceChecklistDocument(belBookDetails objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("[SP_UploadChecklistfileAFA]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCheckListsID", objBEL.ServiceCheckListsID);
                cmd.Parameters.AddWithValue("@ServiceTimeLinesID", objBEL.ServiceTimeLinesID);
                cmd.Parameters.AddWithValue("@Allotmentletterno", objBEL.UserName);
                cmd.Parameters.AddWithValue("@Name", objBEL.filename);
                cmd.Parameters.AddWithValue("@ContentType", objBEL.content);
                cmd.Parameters.AddWithValue("@Path", objBEL.LAWDocPath);
                cmd.Parameters.AddWithValue("@CreatedBy", objBEL.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", objBEL.CreatedDate);
                cmd.Parameters.AddWithValue("@ServiceRequestNo", objBEL.ServiceRequestNO);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
       
        // mashi check user allready exist or not Checkformid
        public DataSet Checkformid(Mpropertymodel objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("spCheckformid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApplicationId", objBEL.ApplicationId);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        public DataSet CheckemailidforaloteeRegister(string email)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("spCheckemailid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", email);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }

        // note use
        public Int32 SaveDirectorsDetailsfin(belBookDetails objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("[Sp_UpdateApplicantDirectorsfin]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AllotteeID", objBEL.AllotteeID);
                cmd.Parameters.AddWithValue("@DirectorName", objBEL.DirectorName);
                cmd.Parameters.AddWithValue("@Address", objBEL.DirectorAddress);
                cmd.Parameters.AddWithValue("@DinPan", objBEL.DirectorDinPan);
                cmd.Parameters.AddWithValue("@Phone", objBEL.DirectorPhone);
                cmd.Parameters.AddWithValue("@Email", objBEL.DirectorEmail);


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        // mashi save applicant details for new user
        public Int32 SaveApplicationforAvailingFinancialAssistance(Mpropertymodel objBEL)
        {
          
            int result;
            try
            {//  old Sp_ApplicationDetaiforAvailingFinancialAssistance 
                SqlCommand cmd = new SqlCommand("[InsertPIPAFARegistration]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ControlID", objBEL.ControlID);
                cmd.Parameters.AddWithValue("@UnitId", objBEL.UnitID);
                cmd.Parameters.AddWithValue("@ServiceId", objBEL.ServiceID);
                cmd.Parameters.AddWithValue("@RequestID", objBEL.RequestID);
                cmd.Parameters.AddWithValue("@AllotteeName", objBEL.ApplicantName);
                cmd.Parameters.AddWithValue("@SignatoryEmail", objBEL.Email);
                cmd.Parameters.AddWithValue("@Designation", objBEL.finDesignation);
                cmd.Parameters.AddWithValue("@SignatoryPhone", objBEL.phoneNo);
                cmd.Parameters.AddWithValue("@PanNo", objBEL.PanNo);
                cmd.Parameters.AddWithValue("@SignatoryAddress", objBEL.Address);
                cmd.Parameters.AddWithValue("@Developerpmtrname", objBEL.Developerpmtrname);
                cmd.Parameters.AddWithValue("@DeveloperpmtrEmail", objBEL.DeveloperpmtrEmail);
                cmd.Parameters.AddWithValue("@isSPV", objBEL.IsSPV);
                cmd.Parameters.AddWithValue("@DeveloperpmtrMobile", objBEL.DeveloperpmtrMobile);
                cmd.Parameters.AddWithValue("@Website", objBEL.Website);
                cmd.Parameters.AddWithValue("@Address", objBEL.Address2);
                cmd.Parameters.AddWithValue("@BranchAddress", objBEL.BranchAddress);
                cmd.Parameters.AddWithValue("@FirmConstitution", objBEL.FirmConstitution);
                cmd.Parameters.AddWithValue("@CompanyName", objBEL.companyName);
                cmd.Parameters.AddWithValue("@BeneficiaryName", objBEL.BeneficiaryName);
                cmd.Parameters.AddWithValue("@BankAccountNo", objBEL.BankAccountNo);
                cmd.Parameters.AddWithValue("@TypeOfAccount", objBEL.TypeOfAccount);
                cmd.Parameters.AddWithValue("@IFSCCode", objBEL.IFSCCode);
                cmd.Parameters.AddWithValue("@NameofBank", objBEL.NameofBank);
                //cmd.Parameters.AddWithValue("@DirectorName1", objBEL.DirectorName1);
                //cmd.Parameters.AddWithValue("@DirectorName2", objBEL.DirectorName2);
                //cmd.Parameters.AddWithValue("@DirectorName3", objBEL.DirectorName3);
                //cmd.Parameters.AddWithValue("@CategoryOfDirectorship1", objBEL.CategoryOfDirectorship1);
                //cmd.Parameters.AddWithValue("@CategoryOfDirectorship2", objBEL.CategoryOfDirectorship2);
                //cmd.Parameters.AddWithValue("@CategoryOfDirectorship3", objBEL.CategoryOfDirectorship3);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        // mashi image save test SaveApplicantImagefIP
        public Int32 SaveApplicantImagefIP(Mpropertymodel objBEL)
        {
            int result;
            try
            {
             SqlCommand cmd = new SqlCommand("[Sp_SaveApplicantImagePIP]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceReqNo", objBEL.ServiceRequestNO);
                cmd.Parameters.AddWithValue("@ApplicantImage", objBEL.ApplicantImageByte);
                cmd.Parameters.AddWithValue("@ApplicantImageName", objBEL.ApplicantImageName);
                cmd.Parameters.AddWithValue("@ApplicantImageType", objBEL.ImageContent);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        // mashi signature  save test SaveApplicantSignfin
        public Int32 SaveApplicantSignfin(Mpropertymodel objBEL)
        {
            int result;
            try
            {// Sp_SaveApplicantSignfin
                
                   SqlCommand cmd = new SqlCommand("[Sp_SaveApplicantSignPIP]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceReqNo", objBEL.ServiceRequestNO);
                cmd.Parameters.AddWithValue("@ApplicantImage", objBEL.ApplicantImageByte);
                cmd.Parameters.AddWithValue("@ApplicantImageName", objBEL.ApplicantImageName);
                cmd.Parameters.AddWithValue("@ApplicantImageType", objBEL.ImageContent);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public DataSet UpdateApplicantfinBasicDetails(Mpropertymodel objBEL)
        {
            DataSet ds = new DataSet();
            try
            {// 05/10/  Sp_UpdateFinanceBasicDetails
                SqlCommand cmd = new SqlCommand("Sp_UpdatePIPFinanceBasicDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ServiceReqNo", objBEL.ServiceRequestNO);
                cmd.Parameters.AddWithValue("@ApplicantName", objBEL.ApplicantName);
                cmd.Parameters.AddWithValue("@emailID", objBEL.Email);
                cmd.Parameters.AddWithValue("@Designation", objBEL.finDesignation);
                cmd.Parameters.AddWithValue("@PhoneNo", objBEL.phoneNo);
                cmd.Parameters.AddWithValue("@PanNo", objBEL.PanNo);
                cmd.Parameters.AddWithValue("@Address1", objBEL.Address);
                cmd.Parameters.AddWithValue("@Developerpmtrname", objBEL.Developerpmtrname);
                cmd.Parameters.AddWithValue("@DeveloperpmtrEmail", objBEL.DeveloperpmtrEmail);
                cmd.Parameters.AddWithValue("@isSPV", objBEL.IsSPV);
                cmd.Parameters.AddWithValue("@DeveloperpmtrMobile", objBEL.DeveloperpmtrMobile);
                cmd.Parameters.AddWithValue("@Website", objBEL.Website);
                cmd.Parameters.AddWithValue("@Address2", objBEL.Address2);
                cmd.Parameters.AddWithValue("@BranchAddress", objBEL.BranchAddress);
                cmd.Parameters.AddWithValue("@FirmConstitution", objBEL.FirmConstitution);
                cmd.Parameters.AddWithValue("@CompanyName", objBEL.companyName);
                cmd.Parameters.AddWithValue("@BeneficiaryName", objBEL.BeneficiaryName);
                cmd.Parameters.AddWithValue("@BankAccountNo", objBEL.BankAccountNo);
                cmd.Parameters.AddWithValue("@TypeOfAccount", objBEL.TypeOfAccount);
                cmd.Parameters.AddWithValue("@IFSCCode", objBEL.IFSCCode);
                cmd.Parameters.AddWithValue("@NameofBank", objBEL.NameofBank);
                cmd.Parameters.AddWithValue("@CreatedBy", objBEL.ApplicantName);
                //cmd.Parameters.AddWithValue("@DirectorName1", objBEL.DirectorName1);
                //cmd.Parameters.AddWithValue("@DirectorName2", objBEL.DirectorName2);
                //cmd.Parameters.AddWithValue("@DirectorName3", objBEL.DirectorName3);
                //cmd.Parameters.AddWithValue("@CategoryOfDirectorship1", objBEL.CategoryOfDirectorship1);
                //cmd.Parameters.AddWithValue("@CategoryOfDirectorship2", objBEL.CategoryOfDirectorship2);
                //cmd.Parameters.AddWithValue("@CategoryOfDirectorship3", objBEL.CategoryOfDirectorship3);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        // mashi   save project details sp_ProjectDetails_save_and_update
        public Int32 Save_and_update_ProjectDetails(Mpropertymodel objBEL)
        {
            int result;
            try
            {
              
                SqlCommand cmd = new SqlCommand("sp_ProjectDetails_save_and_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceReqNo", objBEL.ServiceRequestNO);
                cmd.Parameters.AddWithValue("@PANameofIndustrialPark", objBEL.PANameofIndustrialPark);
                cmd.Parameters.AddWithValue("@PAAreaofIndustrialParkinAcres", objBEL.PAAreaofIndustrialParkinAcres);
                cmd.Parameters.AddWithValue("@FarIndustrialAsPerGuidelines", objBEL.FarIndustrialAsPerGuidelines);
                cmd.Parameters.AddWithValue("@FarCommercialAsPerGuidelines", objBEL.FarCommercialAsPerGuidelines);
                cmd.Parameters.AddWithValue("@FarRoadsAsPerGuidelines", objBEL.FarRoadsAsPerGuidelines);
                cmd.Parameters.AddWithValue("@FarGreenandOpenSpacesAsPerGuidelines", objBEL.FarGreenandOpenSpacesAsPerGuidelines);
                cmd.Parameters.AddWithValue("@FarUtilitiesAsPerGuidelines", objBEL.FarUtilitiesAsPerGuidelines);
                cmd.Parameters.AddWithValue("@FarHostelDormitoryAsPerGuidelines", objBEL.FarHostelDormitoryAsPerGuidelines);
                cmd.Parameters.AddWithValue("@ExemptiononStampDutyinCr", objBEL.ExemptiononStampDutyinCr);
                cmd.Parameters.AddWithValue("@CapitalSubsidyonEligibleFixedCapitalInvestmentinCr", objBEL.CapitalSubsidyonEligibleFixedCapitalInvestmentinCr);
                cmd.Parameters.AddWithValue("@CapitalSubsidyonCostofBuildingHostelDormitoryHousinginCr", objBEL.CapitalSubsidyonCostofBuildingHostelDormitoryHousinginCr);
                cmd.Parameters.AddWithValue("@TotalAmountofFinancialAssistanceSoughtinCr", objBEL.TotalAmountofFinancialAssistanceSoughtinCr);
                cmd.Parameters.AddWithValue("@IRoadsStreetlightingAreainAcres", objBEL.IRoadsStreetlightingAreainAcres);
                cmd.Parameters.AddWithValue("@IRoadsStreetlightingCostinCr", objBEL.IRoadsStreetlightingCostinCr);
                cmd.Parameters.AddWithValue("@IWaterAreainAcres", objBEL.IWaterAreainAcres);
                cmd.Parameters.AddWithValue("@IWaterCostinCr", objBEL.IWaterCostinCr);
                cmd.Parameters.AddWithValue("@ISewerageDrainageAreainAcres", objBEL.ISewerageDrainageAreainAcres);
                cmd.Parameters.AddWithValue("@ISewerageDrainageCostinCr", objBEL.ISewerageDrainageCostinCr);
                cmd.Parameters.AddWithValue("@IPowerSupplyAreainAcres", objBEL.IPowerSupplyAreainAcres);
                cmd.Parameters.AddWithValue("@IPowerSupplyCostinCr", objBEL.IPowerSupplyCostinCr);
              
                cmd.Parameters.AddWithValue("@IWarehousingAreainAcres", objBEL.IWarehousingAreainAcres);
                cmd.Parameters.AddWithValue("@IWarehousingCostinCr", objBEL.IWarehousingCostinCr);
                cmd.Parameters.AddWithValue("@IParkingTruckingBaysAreainAcres", objBEL.IParkingTruckingBaysAreainAcres);
                cmd.Parameters.AddWithValue("@IParkingTruckingBaysCostinCr", objBEL.IParkingTruckingBaysCostinCr);
                cmd.Parameters.AddWithValue("@CFWeightBridgeAreainAcres", objBEL.CFWeightBridgeAreainAcres);
                cmd.Parameters.AddWithValue("@CFWeightBridgeCostinCr", objBEL.CFWeightBridgeCostinCr);
                cmd.Parameters.AddWithValue("@CFSkillDevelopmentCentreAreainAcres", objBEL.CFSkillDevelopmentCentreAreainAcres);
                cmd.Parameters.AddWithValue("@CFSkillDevelopmentCentreCostinCr", objBEL.CFSkillDevelopmentCentreCostinCr);
                cmd.Parameters.AddWithValue("@CFComputerCentreAreainAcres", objBEL.CFComputerCentreAreainAcres);
                cmd.Parameters.AddWithValue("@CFComputerCentreCostinCr", objBEL.CFComputerCentreCostinCr);
                cmd.Parameters.AddWithValue("@CFProductDevelopmentCentreAreainAcres", objBEL.CFProductDevelopmentCentreAreainAcres);
                cmd.Parameters.AddWithValue("@CFProductDevelopmentCentreCostinCr", objBEL.CFProductDevelopmentCentreCostinCr);
                cmd.Parameters.AddWithValue("@CFTestingCentreAreainAcres", objBEL.CFTestingCentreAreainAcres);
                cmd.Parameters.AddWithValue("@CFTestingCentreCostinCr", objBEL.CFTestingCentreCostinCr);
                cmd.Parameters.AddWithValue("@CFRandDCentreAreainAcres", objBEL.CFRandDCentreAreainAcres);
                cmd.Parameters.AddWithValue("@CFRandDCentreCostinCr", objBEL.CFRandDCentreCostinCr);
                cmd.Parameters.AddWithValue("@CFContainerFreightStationAreainAcres", objBEL.CFContainerFreightStationAreainAcres);
                cmd.Parameters.AddWithValue("@CFContainerFreightStationCostinCr", objBEL.CFContainerFreightStationCostinCr);
                cmd.Parameters.AddWithValue("@CFRepairworkshopforVehiclesAreainAcres", objBEL.CFRepairworkshopforVehiclesAreainAcres);
                cmd.Parameters.AddWithValue("@CFRepairworkshopforVehiclesCostinCr", objBEL.CFRepairworkshopforVehiclesCostinCr);
                cmd.Parameters.AddWithValue("@BCFFacilitiesCanteenAreainAcres", objBEL.BCFFacilitiesCanteenAreainAcres);
                cmd.Parameters.AddWithValue("@BCFFacilitiesCanteenCostinCr", objBEL.BCFFacilitiesCanteenCostinCr);
                cmd.Parameters.AddWithValue("@BCFMedicalCentreAreainAcres", objBEL.BCFMedicalCentreAreainAcres);
                cmd.Parameters.AddWithValue("@BCFMedicalCentreCostinCr", objBEL.BCFMedicalCentreCostinCr);
                cmd.Parameters.AddWithValue("@BCFPetrolPumpAreainAcres", objBEL.BCFPetrolPumpAreainAcres);
                cmd.Parameters.AddWithValue("@BCFPetrolPumpCostinCr", objBEL.BCFPetrolPumpCostinCr);
                cmd.Parameters.AddWithValue("@BCFBankingandFinanceAreainAcres", objBEL.BCFBankingandFinanceAreainAcres);
                cmd.Parameters.AddWithValue("@BCFBankingandFinanceCostinCr", objBEL.BCFBankingandFinanceCostinCr);
                cmd.Parameters.AddWithValue("@BCFOfficeSpaceAreainAcres", objBEL.BCFOfficeSpaceAreainAcres);
                cmd.Parameters.AddWithValue("@BCFOfficeSpaceCostinCr", objBEL.BCFOfficeSpaceCostinCr);
                cmd.Parameters.AddWithValue("@BCFHotelRestaurantsAreainAcres", objBEL.BCFHotelRestaurantsAreainAcres);
                cmd.Parameters.AddWithValue("@BCFHotelRestaurantsCostinCr", objBEL.BCFHotelRestaurantsCostinCr);
                cmd.Parameters.AddWithValue("@BCFHospitalDispensaryAreainAcres", objBEL.BCFHospitalDispensaryAreainAcres);
                cmd.Parameters.AddWithValue("@BCFHospitalDispensaryCostinCr", objBEL.BCFHospitalDispensaryCostinCr);
                cmd.Parameters.AddWithValue("@BCFAdministrationOfficeAreainAcres", objBEL.BCFAdministrationOfficeAreainAcres);
                cmd.Parameters.AddWithValue("@BCFAdministrationOfficeCostinCr", objBEL.BCFAdministrationOfficeCostinCr);
                cmd.Parameters.AddWithValue("@BCFWarehousingFacilitiesAreainAcres", objBEL.BCFWarehousingFacilitiesAreainAcres);
                cmd.Parameters.AddWithValue("@BCFWarehousingFacilitiesCostinCr", objBEL.BCFWarehousingFacilitiesCostinCr);
                cmd.Parameters.AddWithValue("@BCFHousingDormitoryHostelforDomicileWorkeAreainAcres", objBEL.BCFHousingDormitoryHostelforDomicileWorkeAreainAcres);
                cmd.Parameters.AddWithValue("@BCFHousingDormitoryHostelforDomicileWorkeCostinCr", objBEL.BCFHousingDormitoryHostelforDomicileWorkeCostinCr);
                cmd.Parameters.AddWithValue("@OtherAreainAcres", objBEL.OtherAreainAcres);
                cmd.Parameters.AddWithValue("@OtherCostinCr", objBEL.OtherCostinCr);
                cmd.Parameters.AddWithValue("@udunitname1", objBEL.udunitname1);
                cmd.Parameters.AddWithValue("@udunitnametype1", objBEL.udunitnametype1);
                cmd.Parameters.AddWithValue("@udunitname2", objBEL.udunitname2);
                cmd.Parameters.AddWithValue("@udunitnametype2", objBEL.udunitnametype2);
                cmd.Parameters.AddWithValue("@udunitname3", objBEL.udunitname3);
                cmd.Parameters.AddWithValue("@udunitnametype3", objBEL.udunitnametype3);
                cmd.Parameters.AddWithValue("@udunitname4", objBEL.udunitname4);
                cmd.Parameters.AddWithValue("@udunitnametype4", objBEL.udunitnametype4);
                cmd.Parameters.AddWithValue("@udunitname5", objBEL.udunitname5);
                cmd.Parameters.AddWithValue("@udunitnametype5", objBEL.udunitnametype5);
                cmd.Parameters.AddWithValue("@Dateofacquiringlandyear1", objBEL.Dateofacquiringlandyear1);
                cmd.Parameters.AddWithValue("@StartofConstructionDateyear1", objBEL.StartofConstructionDateyear1);
                cmd.Parameters.AddWithValue("@CompletionofInfrastructureDateyear1", objBEL.CompletionofInfrastructureDateyear1);
                cmd.Parameters.AddWithValue("@DateofPlacingorderforPlantandMachineryyear1", objBEL.DateofPlacingorderforPlantandMachineryyear1);
                cmd.Parameters.AddWithValue("@InstallationErectionDateyear1", objBEL.InstallationErectionDateyear1);
                cmd.Parameters.AddWithValue("@Proposeddateforcompletionyear1", objBEL.Proposeddateforcompletionyear1);
                cmd.Parameters.AddWithValue("@Dateofacquiringlandyear2", objBEL.Dateofacquiringlandyear2);
                cmd.Parameters.AddWithValue("@StartofConstructionDateyear2", objBEL.StartofConstructionDateyear2);
                cmd.Parameters.AddWithValue("@CompletionofInfrastructureDateyear2", objBEL.CompletionofInfrastructureDateyear2);
                cmd.Parameters.AddWithValue("@DateofPlacingorderforPlantandMachineryyear2", objBEL.DateofPlacingorderforPlantandMachineryyear2);
                cmd.Parameters.AddWithValue("@InstallationErectionDateyear2", objBEL.InstallationErectionDateyear2);
                cmd.Parameters.AddWithValue("@Proposeddateforcompletionyear2", objBEL.Proposeddateforcompletionyear2);
                cmd.Parameters.AddWithValue("@Dateofacquiringlandyear3", objBEL.Dateofacquiringlandyear3);
                cmd.Parameters.AddWithValue("@StartofConstructionDateyear3", objBEL.StartofConstructionDateyear3);
                cmd.Parameters.AddWithValue("@CompletionofInfrastructureDateyear3", objBEL.CompletionofInfrastructureDateyear3);
                cmd.Parameters.AddWithValue("@DateofPlacingorderforPlantandMachineryyear3", objBEL.DateofPlacingorderforPlantandMachineryyear3);
                cmd.Parameters.AddWithValue("@InstallationErectionDateyear3", objBEL.InstallationErectionDateyear3);
                cmd.Parameters.AddWithValue("@Proposeddateforcompletionyear3", objBEL.Proposeddateforcompletionyear3);
                cmd.Parameters.AddWithValue("@Dateofacquiringlandyear4", objBEL.Dateofacquiringlandyear4);
                cmd.Parameters.AddWithValue("@StartofConstructionDateyear4", objBEL.StartofConstructionDateyear4);
                cmd.Parameters.AddWithValue("@CompletionofInfrastructureDateyear4", objBEL.CompletionofInfrastructureDateyear4);
                cmd.Parameters.AddWithValue("@DateofPlacingorderforPlantandMachineryyear4", objBEL.DateofPlacingorderforPlantandMachineryyear4);
                cmd.Parameters.AddWithValue("@InstallationErectionDateyear4", objBEL.InstallationErectionDateyear4);
                cmd.Parameters.AddWithValue("@Proposeddateforcompletionyear4", objBEL.Proposeddateforcompletionyear4);
                cmd.Parameters.AddWithValue("@Dateofacquiringlandyear5", objBEL.Dateofacquiringlandyear5);
                cmd.Parameters.AddWithValue("@StartofConstructionDateyear5", objBEL.StartofConstructionDateyear5);
                cmd.Parameters.AddWithValue("@CompletionofInfrastructureDateyear5", objBEL.CompletionofInfrastructureDateyear5);
                cmd.Parameters.AddWithValue("@DateofPlacingorderforPlantandMachineryyear5", objBEL.DateofPlacingorderforPlantandMachineryyear5);
                cmd.Parameters.AddWithValue("@InstallationErectionDateyear5", objBEL.InstallationErectionDateyear5);
                cmd.Parameters.AddWithValue("@Proposeddateforcompletionyear5", objBEL.Proposeddateforcompletionyear5);
                //
                cmd.Parameters.AddWithValue("@Dateofacquiringlandyear6", objBEL.Dateofacquiringlandyear6);
                cmd.Parameters.AddWithValue("@StartofConstructionDateyear6", objBEL.StartofConstructionDateyear6);
                cmd.Parameters.AddWithValue("@CompletionofInfrastructureDateyear6", objBEL.CompletionofInfrastructureDateyear6);
                cmd.Parameters.AddWithValue("@DateofPlacingorderforPlantandMachineryyear6", objBEL.DateofPlacingorderforPlantandMachineryyear6);
                cmd.Parameters.AddWithValue("@InstallationErectionDateyear6", objBEL.InstallationErectionDateyear6);
                cmd.Parameters.AddWithValue("@Proposeddateforcompletionyear6", objBEL.Proposeddateforcompletionyear6);






                //

                cmd.Parameters.AddWithValue("@EnvironmentalClearances", objBEL.EnvironmentalClearances);
                cmd.Parameters.AddWithValue("@OperationsandMaintenancetobeTakenupby", objBEL.OperationsandMaintenancetobeTakenupby);
                cmd.Parameters.AddWithValue("@CashFlowProjections", objBEL.CashFlowProjections);
                cmd.Parameters.AddWithValue("@ProjectedInflowinCrYear1", objBEL.ProjectedInflowinCrYear1);
                cmd.Parameters.AddWithValue("@ProjectedOutflowinCrYear1", objBEL.ProjectedOutflowinCrYear1);
                cmd.Parameters.AddWithValue("@ProjectedInflowinCrYear2", objBEL.ProjectedInflowinCrYear2);
                cmd.Parameters.AddWithValue("@ProjectedOutflowinCrYear2", objBEL.ProjectedOutflowinCrYear2);
                cmd.Parameters.AddWithValue("@ProjectedInflowinCrYear3", objBEL.ProjectedInflowinCrYear3);
                cmd.Parameters.AddWithValue("@ProjectedOutflowinCrYear3", objBEL.ProjectedOutflowinCrYear3);
                cmd.Parameters.AddWithValue("@ProjectedInflowinCrYear4", objBEL.ProjectedInflowinCrYear4);
                cmd.Parameters.AddWithValue("@ProjectedOutflowinCrYear4", objBEL.ProjectedOutflowinCrYear4);
                cmd.Parameters.AddWithValue("@ProjectedInflowinCrYear5", objBEL.ProjectedInflowinCrYear5);
                cmd.Parameters.AddWithValue("@ProjectedOutflowinCrYear5", objBEL.ProjectedOutflowinCrYear5);
                cmd.Parameters.AddWithValue("@BuildingPlanApprovalStatus", objBEL.BuildingPlanApprovalStatus);
                cmd.Parameters.AddWithValue("@BuildingPlanApprovedfromAuthority", objBEL.BuildingPlanApprovedfromAuthority);
                cmd.Parameters.AddWithValue("@BuildingPlanApplicationIdOBPAS", objBEL.BuildingPlanApplicationIdOBPAS);
                cmd.Parameters.AddWithValue("@OwnershipofHostelDormitoryCompany", objBEL.OwnershipofHostelDormitoryCompany);
                cmd.Parameters.AddWithValue("@AnyOtherInformation", objBEL.AnyOtherInformation);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public DataSet GetAFinancialAssistanceDetails(Mpropertymodel objBEL)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlCommand cmd = new SqlCommand("sp_GetfinDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objBEL.ServiceRequestNO);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();

            }
            catch (Exception ex)
            {

                throw;

            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        public Int32 AddLAWLandDetails(belBookDetails objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("usp_PIP_AFAInsertLandDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LandDeedDate", objBEL.LandDeedDate);
                cmd.Parameters.AddWithValue("@LandArea", objBEL.LandArea);
                cmd.Parameters.AddWithValue("@KhasraNo", objBEL.KhasraNumber);
                cmd.Parameters.AddWithValue("@LandValue", objBEL.LandValue);
                cmd.Parameters.AddWithValue("@ServiceReqNo", objBEL.LAWID);
                cmd.Parameters.AddWithValue("@StampDutyPaid", objBEL.StampDutyPaid);
                cmd.Parameters.AddWithValue("@District", objBEL.LAWDistrict);
                cmd.Parameters.AddWithValue("@Tehsil", objBEL.LAWTehsil);
                cmd.Parameters.AddWithValue("@Village", objBEL.LAWVillage);
                cmd.Parameters.AddWithValue("@ExistingLand", objBEL.ExistingLand);
                cmd.Parameters.AddWithValue("@LandContiguousStatus", objBEL.LandContiguousStatus);
                cmd.Parameters.AddWithValue("@LandContiguous", objBEL.LandContiguous);
                cmd.Parameters.AddWithValue("@GramGovStatus", objBEL.GramGovStatus);
                cmd.Parameters.AddWithValue("@GramGov", objBEL.GramGov);
                cmd.Parameters.AddWithValue("@LandExchangeStatus", objBEL.LandExchangeStatus);
                cmd.Parameters.AddWithValue("@LandExchange", objBEL.LandExchange);
                cmd.Parameters.AddWithValue("@LandConversionChargesPaidifanyinCr", objBEL.LandConversionChargesPaidifanyinCr);
                cmd.Parameters.AddWithValue("@RegistrationFeesPaidinCr", objBEL.RegistrationFeesPaidinCr);
                cmd.Parameters.AddWithValue("@AnyOtherDetails", objBEL.PIPOtherDetails);
                cmd.Parameters.AddWithValue("@anyOtherExistingProject", objBEL.anyOtherExistingProject);


                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public Int32 UpdateLAWLandDetails(belBookDetails objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("usp_PIP_AFALandDetailsUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LandDeedDate", objBEL.LandDeedDate);
                cmd.Parameters.AddWithValue("@LandArea", objBEL.LandArea);
                cmd.Parameters.AddWithValue("@KhasraNo", objBEL.KhasraNumber);
                cmd.Parameters.AddWithValue("@LandValue", objBEL.LandValue);
                cmd.Parameters.AddWithValue("@LAWLandID", objBEL.LAWLandID);
                cmd.Parameters.AddWithValue("@StampDutyPaid", objBEL.StampDutyPaid);
                cmd.Parameters.AddWithValue("@District", objBEL.LAWDistrict);
                cmd.Parameters.AddWithValue("@Tehsil", objBEL.LAWTehsil);
                cmd.Parameters.AddWithValue("@Village", objBEL.LAWVillage);
                cmd.Parameters.AddWithValue("@ExistingLand", objBEL.ExistingLand);
                cmd.Parameters.AddWithValue("@LandContiguousStatus", objBEL.LandContiguousStatus);
                cmd.Parameters.AddWithValue("@LandContiguous", objBEL.LandContiguous);
                cmd.Parameters.AddWithValue("@GramGovStatus", objBEL.GramGovStatus);
                cmd.Parameters.AddWithValue("@GramGov", objBEL.GramGov);
                cmd.Parameters.AddWithValue("@LandExchangeStatus", objBEL.LandExchangeStatus);
                cmd.Parameters.AddWithValue("@LandExchange", objBEL.LandExchange);
                cmd.Parameters.AddWithValue("@LandConversionChargesPaidifanyinCr", objBEL.LandConversionChargesPaidifanyinCr);
                cmd.Parameters.AddWithValue("@RegistrationFeesPaidinCr", objBEL.RegistrationFeesPaidinCr);
                cmd.Parameters.AddWithValue("@AnyOtherDetails", objBEL.PIPOtherDetails);
                cmd.Parameters.AddWithValue("@anyOtherExistingProject", objBEL.anyOtherExistingProject);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public DataSet GetLAWLandDetails(belBookDetails objBEL)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[usp_GetPIP_AFA_LandDetails]", con);

                cmd.Parameters.AddWithValue("@ServiceRequestNO", objBEL.ServiceRequestNO);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        public Int32 DeleteLAWLandDetail(belBookDetails objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("[usp_Delete_PIP_AFA_LandDetails]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", objBEL.LAWLandID);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
    }
}