using System;
using System.Collections.Generic;
using System.Text;

namespace APIGateway.AcceptanceTest.Test_endpints.V1
{ 
    public class Test_endpont_routes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Hrm_setup_endpoints
        {
            //academic discipline
            public const string ADD_UPDATE_ACADEMIC_DISCPLINE = Base + "/hrmsetup/add/update/academic/discipline";
            public const string DELETE_ACADEMIC_DISCPLINE = Base + "/hrmsetup/delete/academic/discipline";
            public const string GET_ALL_ACADEMIC_DISCPLINE = Base + "/hrmsetup/get/all/academic/disciplines";
            public const string GET_SINGLE_ACADEMIC_DISCPLINE = Base + "/hrmsetup/get/single/academic/discipline";
            public const string DOWNLOAD_ACADEMIC_DISCPLINE = Base + "/hrmsetup/download/academic/disciplines";
            public const string UPLOAD_ACADEMIC_DISCIPLINE = Base + "/hrmsetup/upload/academic/discipline";

            //academic grades
            public const string ADD_UPDATE_ACADEMIC_GRADES = Base + "/hrmsetup/add/update/academic/grade";
            public const string DELETE_ACADEMIC_GRADES = Base + "/hrmsetup/delete/academic/grade";
            public const string GET_ALL_ACADEMIC_GRADES = Base + "/hrmsetup/get/all/academic/grades";
            public const string GET_SINGLE_ACADEMIC_GRADES = Base + "/hrmsetup/get/single/academic/grade";
            public const string DOWNLOAD_ACADEMIC_GRADES = Base + "/hrmsetup/download/academic/grades";
            public const string UPLOAD_ACADEMIC_GRADE = Base + "/hrmsetup/upload/academic/grade";

            //academic qualification
            public const string ADD_UPDATE_ACADEMIC_QUALIFICATION = Base + "/hrmsetup/add/update/academic/qualification";
            public const string DELETE_ACADEMIC_QUALIFICATION = Base + "/hrmsetup/delete/academic/qualification";
            public const string GET_ALL_ACADEMIC_QUALIFICATION = Base + "/hrmsetup/get/all/academic/qualifications";
            public const string GET_SINGLE_ACADEMIC_QUALIFICATION = Base + "/hrmsetup/get/single/academic/qualification";
            public const string DOWNLOAD_ACADEMIC_QUALIFICATIONS = Base + "/hrmsetup/download/academic/qualifications";
            public const string UPLOAD_ACADEMIC_QUALIFICATION = Base + "/hrmsetup/upload/academic/qualification";

            //employment type
            public const string ADD_UPDATE_EMPLYMENT_TYPE = Base + "/hrmsetup/add/update/employmenttype";
            public const string DELETE_EMPLYMENT_TYPE = Base + "/hrmsetup/delete/employmenttype";
            public const string GET_ALL_EMPLYMENT_TYPE = Base + "/hrmsetup/get/all/employmenttypes";
            public const string GET_SINGLE_EMPLYMENT_TYPE = Base + "/hrmsetup/get/single/employmenttype";
            public const string DOWNLOAD_EMPLOYMENT_TYPE = Base + "/hrmsetup/download/employmenttypes";
            public const string UPLOAD_EMPLOYMENT_TYPE = Base + "/hrmsetup/upload/employmenttype";

            //employment level
            public const string ADD_UPDATE_EMPLYMENT_LEVEL = Base + "/hrmsetup/add/update/employmentlevel";
            public const string DELETE_EMPLYMENT_LEVEL = Base + "/hrmsetup/delete/employmentlevel";
            public const string GET_ALL_EMPLYMENT_LEVEL = Base + "/hrmsetup/get/all/emplpymentlevels";
            public const string GET_SINGLE_EMPLYMENT_LEVEL = Base + "/hrmsetup/get/single/employmentlevel";
            public const string DOWNLOAD_EMPLOYMENT_LEVEL = Base + "/hrmsetup/download/employmentlevels";
            public const string UPLOAD_EMPLOYMENT_LEVEL = Base + "/hrmsetup/upload/employmentlevel";

            //gym workout
            public const string ADD_UPDATE_GYM_WORKOUT = Base + "/hrmsetup/add/update/gymworkout";
            public const string DELETE_GYM_WORKOUT = Base + "/hrmsetup/delete/gymworkout";
            public const string GET_ALL_GYM_WORKOUT = Base + "/hrmsetup/get/all/gymworkouts";
            public const string GET_SINGLE_GYM_WORKOUT = Base + "/hrmsetup/get/single/gymworkout";
            public const string DOWNLOAD_GYM_WORKOUT = Base + "/hrmsetup/download/gymworkouts";
            public const string UPLOAD_GYM_WORKOUT = Base + "/hrmsetup/upload/gymworkout";

            //high_school_grade
            public const string ADD_UPDATE_HIGH_SCHOOL_GRADE = Base + "/hrmsetup/add/update/highschoolgrade";
            public const string DELETE_HIGH_SCHOOL_GRADE = Base + "/hrmsetup/delete/highschoolgrade";
            public const string GET_ALL_HIGH_SCHOOL_GRADE = Base + "/hrmsetup/get/all/highschoolgrades";
            public const string GET_SINGLE_HIGH_SCHOOL_GRADE = Base + "/hrmsetup/get/single/highschoolgrade";
            public const string DOWNLOAD_HIGH_SCHOOL_GRADE = Base + "/hrmsetup/download/highschoolgrades";
            public const string UPLOAD_HIGH_SCHOOL_GRADE = Base + "/hrmsetup/upload/highschoolgrade";

            //high_school_subjects
            public const string ADD_UPDATE_HIGH_SCHOOL_SUBJECT = Base + "/hrmsetup/add/update/highschoolsubject";
            public const string DELETE_HIGH_SCHOOL_SUBJECT = Base + "/hrmsetup/delete/highschoolsubject";
            public const string GET_ALL_HIGH_SCHOOL_SUBJECT = Base + "/hrmsetup/get/all/highschoolsubjects";
            public const string GET_SINGLE_HIGH_SCHOOL_SUBJECT = Base + "/hrmsetup/get/single/highschoolsubject";
            public const string DOWNLOAD_HIGH_SCHOOL_SUBJECT = Base + "/hrmsetup/download/highschoolsubjects";
            public const string UPLOAD_HIGH_SCHOOL_SUBJECT = Base + "/hrmsetup/upload/highschoolsubject";

            //hmo
            public const string ADD_UPDATE_HMO = Base + "/hrmsetup/add/update/hmo";
            public const string DELETE_HMO = Base + "/hrmsetup/delete/hmo";
            public const string GET_ALL_HMO = Base + "/hrmsetup/get/all/hmos";
            public const string GET_SINGLE_HMO = Base + "/hrmsetup/get/single/hmo";
            public const string DOWNLOAD_HMO = Base + "/hrmsetup/download/hmo";
            public const string UPLOAD_HMO = Base + "/hrmsetup/upload/hmo";

            //job details
            public const string ADD_UPDATE_JOB_DETAILS = Base + "/hrmsetup/add/update/jobdetail";
            public const string DELETE_JOB_DETAILS = Base + "/hrmsetup/delete/jobdetail";
            public const string GET_ALL_JOB_DETAILS = Base + "/hrmsetup/get/all/jobdetails";
            public const string GET_SINGLE_JOB_DETAILS = Base + "/hrmsetup/get/single/jobdetail";
            public const string DOWNLOAD_JOB_DETAILS = Base + "/hrmsetup/download/jobdetails";
            public const string UPLOAD_JOB_DETAILS = Base + "/hrmsetup/upload/jobdetail";

            //job grade
            public const string ADD_UPDATE_JOB_GRADE = Base + "/hrmsetup/add/update/jobgrade";
            public const string DELETE_JOB_GRADE = Base + "/hrmsetup/delete/jobgrade";
            public const string GET_ALL_JOB_GRADE = Base + "/hrmsetup/get/all/jobgrades";
            public const string GET_SINGLE_JOB_GRADE = Base + "/hrmsetup/get/single/jobgrade";
            public const string DOWNLOAD_JOB_GRADE = Base + "/hrmsetup/download/jobgrade";
            public const string UPLOAD_JOB_GRADE = Base + "/hrmsetup/upload/jobgrade";

            //language
            public const string ADD_UPDATE_LANGUAGE = Base + "/hrmsetup/add/update/language";
            public const string DELETE_LANGUAGE = Base + "/hrmsetup/delete/language";
            public const string GET_ALL_LANGUAGE = Base + "/hrmsetup/get/all/languages";
            public const string GET_SINGLE_LANGUAGE = Base + "/hrmsetup/get/single/language";
            public const string DOWNLOAD_LANGUAGE = Base + "/hrmsetup/download/languages";
            public const string UPLOAD_LANGUAGE = Base + "/hrmsetup/upload/language";

            //prf membership
            public const string ADD_UPDATE_PROF_MEMBERSHIP = Base + "/hrmsetup/add/update/prof_membership";
            public const string DELETE_PROF_MEMBERSHIP = Base + "/hrmsetup/delete/prof_membership";
            public const string GET_ALL_PROF_MEMBERSHIP = Base + "/hrmsetup/get/all/prof_membership";
            public const string GET_SINGLE_PROF_MEMBERSHIP = Base + "/hrmsetup/get/single/prof_membership";
            public const string DOWNLOAD_PROF_MEMBERSHIP = Base + "/hrmsetup/download/prof_memberships";
            public const string UPLOAD_PROF_MEMBERSHIP = Base + "/hrmsetup/upload/prof_membership";

            //prf certification
            public const string ADD_UPDATE_PROF_CERTIFICATION = Base + "/hrmsetup/add/update/prof_certification";
            public const string DELETE_PROF_CERTIFICATION = Base + "/hrmsetup/delete/prof_certification";
            public const string GET_ALL_PROF_CERTIFICATION = Base + "/hrmsetup/get/all/prof_certification";
            public const string GET_SINGLE_PROF_CERTIFICATION = Base + "/hrmsetup/get/single/prof_certification";
            public const string DOWNLOAD_PROF_CERTIFICATION = Base + "/hrmsetup/download/prof_certifications";
            public const string UPLOAD_PROF_CERTIFICATION = Base + "/hrmsetup/upload/prof_certification";

            //sub skill
            public const string UPLOAD_SUB_SKILL = Base + "/hrmsetup/upload/sub_skill";
            public const string ADD_UPDATE_SUB_SKILL = Base + "/hrmsetup/add/update/sub_skill";
            public const string GET_ALL_SUB_SKILL = Base + "/hrmsetup/get/all/sub_skill";
            public const string DELETE_SUB_SKILL = Base + "/hrmsetup/delete/sub_skill";
            public const string GET_SINGLE_SUB_SKILL = Base + "/hrmsetup/get/single/sub_skill";
            public const string DOWNLOAD_SUB_SKILL = Base + "/hrmsetup/download/sub_skill";


        }
        public static class EmailEndpoint
        {
            public const string SEND_EMAIL = Base + "/email/send/emails";
            public const string SEND_EMAIL_TO_SPECIFIC_OFFICERS = Base + "/email/send/specific/emails";
            public const string GET_USER_EMAILS = Base + "/email/get/all/useremails";
            public const string GET_SINGLE_EMAIL = Base + "/email/get/single/email";
            public const string GET_ALL_EMAIL_CONFIG = Base + "/email/get/all/emailconfig";
            public const string GET_EMAIL_CONFIG = Base + "/email/get/single/emailconfig";
            public const string ADD_UPDATE_EMAIL_CONFIG = Base + "/email/add/update/emailconfig";
            public const string DELETE_EMAIL_CONFIG = Base + "/email/delete/emailconfig/targetIds";
        }

        public static class Identity
        {
            public const string LOGIN = Base + "/identity/login";
            public const string OTP_LOGIN = Base + "/identity/otp/login";
            public const string LOGIN_OUT = Base + "/identity/logout";
            public const string ANSWAER = Base + "/identity/answer/question";
            public const string REGISTER = Base + "/identity/register";
            public const string REFRESHTOKEN = Base + "/identity/refresh";
            public const string CHANGE_PASSWORD = Base + "/identity/changePassword";
            public const string CONFIRM_EMAIL = Base + "/identity/confirmEmail";
            public const string FETCH_USERDETAILS = Base + "/identity/profile";
            public const string CONFIRM_CODE = Base + "/identity/confirmCode";
            public const string RECOVER_PASSWORD_BY_EMAIL = Base + "/identity/recoverpassword/byemail";
            public const string NEW_PASS = Base + "/identity/newpassword";
            public const string UPDATE_PASS = Base + "/identity/update/password";
        }

        public static class PersmissionsEndpoint
        {
            public const string CAN_ADD = Base + "/workflow/staff/canadd";
            public const string CAN_EDIT = Base + "/workflow/staff/canedit";
            public const string CAN_UPDATE = Base + "/workflow/staff/canupdate";
            public const string CAN_DELETE = Base + "/workflow/staff/candelete";
        }
        public static class AdminEndpoints
        {
            public const string GET_ALL_ACTIVITY_PAREANTS = Base + "/admin/get/all/activityParents";
            public const string GET_ALL_ACTIVITIES = Base + "/admin/get/all/activities";
            public const string UPDATE_STAFF_USER = Base + "/admin/add/update/staff";
            public const string GET_ALL_STAFF = Base + "/admin/get/all/staff";
            public const string UPDATE_ROLE_ACTIVITY = Base + "/admin/add/update/roleActivity";
            public const string DELETE_ROLE = Base + "/admin/delete/role/targetIds";
            public const string GET_ALL_ROLES = Base + "/admin/get/all/role";
            public const string GET_THIS_USER_ROLES = Base + "/admin/get/this/userroles";
            public const string DELETE_STAFF = Base + "/admin/delete/staff/targetIds";
            public const string GET_ALL_ACTIVITIES_BY_ROLE_ID = Base + "/admin/get/all/roleActivities/roleId";
            public const string GENERATE_STAFF_EXCEL = Base + "/admin/generate/excel/staff";
            public const string UPLOAD_STAFF_EXCEL = Base + "/admin/upload/excel/staff";
            public const string GET_STAFF = Base + "/admin/get/single/staff/staffId";

            public const string ADD_MODULE = Base + "/admin/add/update/solution/module";
            public const string DELETE_MODULE = Base + "/admin/delete/solution/module";
            public const string GET_SINGLE_MODULE = Base + "/admin/get/single/solution/module";
            public const string GET_ALL_MODULE = Base + "/admin/get/all/solution/module";

            public const string GET_ALL_QUESTIONS = Base + "/admin/get/all/questions";
            public const string GET_QUESTION = Base + "/admin/get/single/questions";
            public const string ADD_UPDATE_QUESTION = Base + "/admin/add/update/questions";
            public const string DELETE_QUESTION = Base + "/admin/delete/questions";
            public const string RESET_PROFILE = Base + "/admin/reset/profile";
        }


        public static class ComapnyEndPoints
        {

            public const string ADD_UPDATE_COMPANY_STRUCTURE_DEFINITION = Base + "/company/add/update/companystructureDefinition";
            public const string DELETE_COMPANY_STRUCTURE_DEF = Base + "/company/delete/companystructureDefinition";
            public const string GENERATE_EXCEL_FOR_COMP_STRU_DEF = Base + "/company/generate/excel/companystructureDefinition";
            public const string GET_ALL_COMPANY_STRUCTURE_DEFINITION = Base + "/company/get/all/companystructureDefinition";
            public const string UPLOAD_COMPANY_STRUCTURE_DEF = Base + "/company/upload/companystructureDefinition";
            public const string GET_COMPANY_STRUCTURE_BY_DEF = Base + "/company/get/single/companystructure/companystructureDefinitionId";
            public const string GET_COMPANY_STRUCTURE_FSTEMPLATE = Base + "/company/get/single/companystructure/fstemplate";

            public const string UPLOAD_FS_TEMPLATE = Base + "/company/upload/fstemplate";



            public const string ADD_UPDATE_COMPANY_STRUCTURE = Base + "/company/add/update/companystructure";
            public const string UPDATE_COMPANY_STRUCTURE = Base + "/company/update/companystructure";
            public const string GET_ALL_COMPANY_STRUCTURE_BY_ACCESSID = Base + "/company/get/all/companystructure/accessId";
            public const string GET_COMPANY_STRUCTURE = Base + "/company/get/single/companystructure/id";
            public const string UPLOAD_COMPANY_STRUCTURE = Base + "/company/upload/companystructure";
            public const string GET_COMPANY_STRUCTURE_BY_STAFFID = Base + "/company/get/companystructure/staffId";
            public const string DELETE_COMPANY_STRUCTURE = Base + "/company/delete/companystructure/targetIds";
            public const string ADD_UPDATE_ADD_COMPANY_STRUCTURE_INFO = Base + "/company/update/additional/companystructureInfo/";
            public const string GET_COMPANY_STRUCTURE_INFO = Base + "/company/get/single/companystructureInfoId";
            public const string GET_ALL_COMPANY_STRUCTURE = Base + "/company/get/all/companystructures";
            public const string GET_ALL_COMPANY_STRUCTURE2 = Base + "/company/get/all/companystructures2";

            //public const string UPLOAD_FS_TEMPLATE = Base + "/company/upload/FSTemplate";
            public const string GET_COMPANY_EXCHANGE = Base + "/company/get/exhangerate";

            public const string GET_COMPANY_STRUCTUREDEFINITION_EXCHANGE = Base + "/company/get/single/companystructuredefinition/Id";

            public const string DOWNLOAD_COMPANY_STRUCTURE = Base + "/company/download/companystructure";


        }

        public static class WorkdlowEndpoints
        {
            public const string ADD_UPDATE_WKF_GROUP = Base + "/workflow/add/updadte/workflowgroup";
            public const string DELETE_WKF_GROUP = Base + "/workflow/delete/workflowgroups/targetIds";
            public const string GET_WKF_GROUP = Base + "/workflow/get/single/workflowgroup/workflowgroupId";
            public const string GET_ALL_WKF_GROUP = Base + "/workflow/get/all/workflowgroups";
            public const string GET_ALL_OPERATION_TYPES = Base + "/workflow/get/all/operationTypes";
            public const string GET_ALL_OPERATIONS = Base + "/workflow/get/all/operations";
            // public const string GENERATE_EXCEL_OPERA = Base + "/workflow/generate/excel/operations";
            public const string GENERATE_EXCEL_WKF_group = Base + "/workflow/generate/excel/workflowgroup";
            public const string GENERATE_EXCEL_WKF_Level = Base + "/workflow/generate/excel/workflowlevel";
            public const string UPLOAD_WORK_FLOW_GRP = Base + "/workflow/upload/workflowgroups";
            public const string GET_ALL_WKF_LEVEL = Base + "/workflow/get/workflowlevels";
            public const string GET_ALL_WKFL_BY_WKF_GROUP = Base + "/workflow/get/all/workflowLevel/workflowgroupId";
            public const string GET_WKF_LEVEL = Base + "/workflow/get/single/workflowlevelId";
            public const string ADD_UPDATE_WKF_LEVEL = Base + "/workflow/add/update/workflowLevel";
            public const string DELETE_WKF_LEVEL = Base + "/workflow/delete/workflowLevel/targetIds";
            public const string UPLOAD_WKF_LEVEL = Base + "/workflow/upload/workflowLevel";
            public const string ADD_UPDATE_WKF_LEVEL_STAFF = Base + "/workflow/add/update/workflowLevelStaff";
            public const string DELETE_WKF_LEVEL_STAFF = Base + "/workflow/delete/workflowLevelStaff/targetIds";
            public const string GET_WKF_LEVEL_STAFF = Base + "/workflow/get/single/workflowLevelStaff/workflowLevelStaffId";
            public const string GET_ALL_WKF_LEVEL_STAFF = Base + "/workflow/get/all/workflowLevelStaff";
            public const string GET_WKF_LEVEL_STAFF_BY_STAFFID = Base + "/workflow/get/single/workflowLevelStaff/staffId";
            public const string GET_WORKFLOW_BY_OPERATION = Base + "/workflow/get/all/workflow/operationId";
            public const string GET_WORKFLOW = Base + "/workflow/get/single/workflow/workflowId";
            public const string GET_WORKFLOW_DETAILS = Base + "/workflow/get/workflowDetails/workflowId";
            public const string ADD_UPDATE_WORKFLOW = Base + "/workflow/add/update/workflow";
            public const string DELETE_WORKFLOW = Base + "/workflow/delete/workflowIds";
            public const string GET_ALL_WKF_OPERATION = Base + "/workflow/get/all/workflowOperation";
            public const string UPDATE_WKF_OPERATION = Base + "/workflow/update/all/workflowOperation";

            public const string GO_FOR_APPROVAL = Base + "/workflow/goThroughApprovalFromCode";
            public const string GET_ALL_STAFF_AWAITING_APPROVALS = Base + "/workflow/get/all/staffAwaitingApprovalsFromCode";
            public const string STAFF_APPROVAL_REQUEST = Base + "/workflow/staff/approvaltask";

            public const string DOWNLOAD_LEVEL_STAFF = Base + "/workflow/download/workflowlevelstaff";
            public const string UPLOAD_LEVEL_STAFF = Base + "/workflow/upload/workflowlevelstaff";
        }

        public static class CommonEnpoint
        {
            public const string BRANCHES = Base + "/common/branches";
            public const string CALL_MEMO_TYPE = Base + "/common/callMemoType";
            public const string CITY = Base + "/common/cities";
            public const string CITY_BY_STATE = Base + "/common/get/cities/stateId";
            public const string CREDITBUREAU = Base + "/common/creditBureau";
            public const string COUNTRY = Base + "/common/countries";
            public const string CURRENCY = Base + "/common/currencies";
            public const string IDENTITY = Base + "/common/Identifications";
            public const string DEPARTMENT = Base + "/common/departments";
            public const string DIRECTOR_TYPE = Base + "/common/directorTypes";
            public const string DOCUMENT_TYPE = Base + "/common/documentypes";
            public const string EMPLOYER_TYPE = Base + "/common/employerTypes";
            public const string GENDER = Base + "/common/genders";
            public const string GL_ACCOUNT = Base + "/common/glaccount";
            public const string LMO_TYPE = Base + "/common/loanManagementOperationType";
            public const string MARITAL_STATUS = Base + "/common/maritalStatus";
            public const string MODULES = Base + "/common/modules";
            public const string PRODUCT_TYPE = Base + "/common/productType";
            public const string STATE = Base + "/common/states";
            public const string STATE_BY_COUNTRY = Base + "/common/get/states/countryId";
            public const string TITLE = Base + "/common/title";
            public const string JOB_TITLE = Base + "/common/jobTitles";
            public const string CURRENCY_RATE = Base + "/common/currencyRates";
            public const string CURRENCY_RATE_BY_CURRENCY = Base + "/common/currencyRates/currencyId";

            public const string ADD_UPDATE_BRANCH = Base + "/common/add/update/branch";
            public const string ADD_UPDATE_STATE = Base + "/common/add/update/state";
            public const string ADD_UPDATE_CITY = Base + "/common/add/update/city";
            public const string ADD_UPDATE_COUNTRY = Base + "/common/add/update/country";
            public const string ADD_UPDATE_JOB_TITLE = Base + "/common/add/update/jobTitle";
            public const string ADD_UPDATE_DOCU_TYPE = Base + "/common/add/update/documentType";
            public const string ADD_UPDATE_CURRENT_RATE = Base + "/common/add/update/currencyRate";
            public const string ADD_UPDATE_IDENTITY = Base + "/common/add/update/identification";
            public const string ADD_UPDATE_CURRENCY = Base + "/common/add/update/currency";
            public const string ADD_UPDATE_CREDITBUREAU = Base + "/common/add/update/creditBureau";

            public const string DELETE_CREDITBUREAU = Base + "/common/delete/creditBureauById";
            public const string DELETE_COUNTRY = Base + "/common/delete/countryById";
            public const string DELETE_JOB_TITLE = Base + "/common/delete/jobTitleById";
            public const string DELETE_CITY = Base + "/common/delete/cityById";
            public const string DELETE_CURRENCY_RATE = Base + "/common/delete/currencyRateById";
            public const string DELETE_IDENTIFICATION = Base + "/common/delete/identificationById";
            public const string DELETE_DOCUMENT_TYPE = Base + "/common/delete/documentTypeById";
            public const string DELETE_CURRENCY = Base + "/common/delete/currencyById";
            public const string DELETE_BRANCH = Base + "/common/delete/branchById";
            public const string DELETE_STATE = Base + "/common/delete/stateId";

            public const string GET_CREDITBUREAU = Base + "/common/get/single/creditBureauById";
            public const string GET_COUNTRY = Base + "/common/get/single/countryById";
            public const string GET_STATE = Base + "/common/get/single/stateById";
            public const string GET_JOB_TITLE = Base + "/common/get/get/single/jobTitleById";
            public const string GET_CITY = Base + "/common/get/get/single/cityById";
            public const string GET_CURRENCY_RATE = Base + "/common/get/single/currencyRateById";
            public const string GET_IDENTIFICATION = Base + "/common/get/single/identificationById";
            public const string GET_DOCUMENT_TYPE = Base + "/common/get/single/documentTypeById";
            public const string GET_CURRENCY = Base + "/common/get/single/currencyById";
            public const string GET_BRANCH = Base + "/common/get/single/branchById";

            public const string UPLOAD_COUNTRY = Base + "/common/upload/countries";
            public const string UPLOAD_STATE = Base + "/common/upload/states";
            public const string UPLOAD_CITY = Base + "/common/upload/city";
            public const string UPLOAD_CURRENCY = Base + "/common/upload/currency";
            public const string DOWNLOAD_COUNTRY = Base + "/common/download/countries";
            public const string DOWNLOAD_STATE = Base + "/common/download/states";
            public const string DOWNLOAD_CITY = Base + "/common/download/cities";
            public const string DOWNLOAD_CURRENCY = Base + "/common/download/currencies";
            public const string DOWNLOAD_JOB_TITLE = Base + "/common/download/jobtitle";
            public const string UPLOAD_JOB_TITLE = Base + "/common/upload/jobtitle";
            public const string DOWNLOAD_CURRENCYRATE = Base + "/common/download/currenyrate";
            public const string UPLOAD_CURRENCYRATE = Base + "/common/upload/uploadrate";
            public const string DOWNLOAD_DOCUMENTTYPE = Base + "/common/download/documenttype";
            public const string UPLOAD_DOCUMENTTYPE = Base + "/common/upload/documenttype";
            public const string DOWNLOAD_IDENTIFICATION = Base + "/common/download/identification";
            public const string UPLOAD_IDENTIFICATION = Base + "/common/upload/identification";
        }


    }
}
