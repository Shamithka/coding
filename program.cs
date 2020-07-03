using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserInput selectedPaymentType = new UserInput();
                PaymentType(selectedPaymentType);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static void PaymentType(UserInput selectedPaymentType)
        {
            switch (selectedPaymentType.Type)
            {
                case constants.PhysicalProduct:
                    var productdetails = PhysicalProductBR();
                    CommisionGeneration(productdetails.AgentId);
                    break;
                case constants.Book:
                    var bookDetails= BookBR();
                    CommisionGeneration(bookDetails.AgentId);
                    break;
                case constants.Membership:
                    MembershipActivation();
                    break;
                case constants.MembershipUpgrade:
                    MembershipUpgrade(selectedPaymentType.Id);
                    break;
                case constants.VideoTutorials:
                    Tutorials();
                    break;
                default:
                    break;
            }
        }

        
        private static void Tutorials()
        {
            try
            {
                //get the type of Tutorils
                bool isSkying = true;
                if (isSkying)
                {
                    AddFreeFirstAdiVideo(true);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private static void AddFreeFirstAdiVideo(bool v)
        {
            //Read this data from a config file cause as it is a offer, it can expire anytime.
        }

        #region Activate membership
        private static void MembershipUpgrade(int id)
        {
            try
            {
                 GetmemberShipUpgraded(id);
            }
            catch (Exception ex)
            {

            }
        }


        private static bool GetmemberShipUpgraded(int id)
        {
            try
            {
                checkifValidMember(id);

                var res = UpgradeMembership(id) != null ? true : false;
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static MembershipDetails UpgradeMembership(int id)
        {
            try
            {
                //Step 1 :Check if menbership expired 
                //Step 2 :Check if all the details are valid and payment is recieved 
                var res = true;
                if (res)
                {
                    MembershipDetails membershipDetails = GetMembershipDetails(id);
                    membershipDetails.ExpiryDate= DateTime.Today.AddYears(1);
                    return membershipDetails;
                }
                return null;
            }
            catch(Exception x)
            {
                throw x;
            }
        }

        private static bool checkifValidMember(int id)
        {
            MembershipDetails membershipDetails = GetMembershipDetails(id);
            //verify the Detials of membershipDetails object
            var res = true;
            if (res)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static MembershipDetails GetMembershipDetails(int id)
        {
            try
            {

                MembershipDetails mb = new MembershipDetails();
                //call aApi to get details
                //mb = GetdetailsMemberAPICall();
                return mb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void MembershipActivation()
        {
            try
            {
                CreateNewMembership();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region New member
        private static void CreateNewMembership()
        {
            try
            {
                MembershipDetails membershipDetails = new MembershipDetails();
                var mid = new Guid();
                membershipDetails.ID = Convert.ToInt32(mid);
                Console.WriteLine("Please enter your Name");
                membershipDetails.MemberName = Console.ReadLine();
                membershipDetails.fees = 100;
                membershipDetails.ExpiryDate = DateTime.Now.AddYears(1);
                Console.WriteLine("Dear member your Details are as follows Name : {0}, Membership Fee : {1} , MembershipExpiryDate : {2}", membershipDetails.MemberName,membershipDetails.fees,membershipDetails.ExpiryDate);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Physical Product 
        private static PackageSlipDetails PhysicalProductBR()
        {
            try
            {
                return GetProductDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static PackageSlipDetails GetProductDetails()
        {
            try
            {
                return PackageSlip();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static PackageSlipDetails PackageSlip()
        {
            try
            {
                PackageSlipDetails Slip = new PackageSlipDetails();
                //Logic to generate Duplicate slip, it goes somethig like this, Call an APi to Get the Details and create a object
                Slip.AgentId = 1;
                Slip.Description = "Description";
                Slip.id = 1;
                return Slip;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Books
        private static DuplicatePackageSlipDetails GetBookDetails()
        {
            try
            {
                return DuplicatePackingSlip();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static DuplicatePackageSlipDetails DuplicatePackingSlip()
        {
            try
            {
                DuplicatePackageSlipDetails Slip = new DuplicatePackageSlipDetails();
                //Logic to generate Duplicate slip, it goes somethig like this, Call an APi to Get the Details and create a object
                Slip.AgentId = 1;
                Slip.Description = "Description";
                Slip.id = 1;
                return Slip;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static DuplicatePackageSlipDetails BookBR()
        {
            try
            {
                return GetBookDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region   Comissionregion
        private static void CommisionGeneration(int agentId)
        {
            try
            {
                GenerateComission(agentId);
            }
            catch (Exception ex)
            {

            }
        }

        private static void GenerateComission(int agentId)
        {
            //Bussiness login to generate comission based on the sales amount and region
        }
        #endregion
    }

    public class constants
    {
        public const string PhysicalProduct = "1";
        public const string Book = "2";
        public const string Membership = "3";
        public const string MembershipUpgrade = "4";
        public const string VideoTutorials = "5";
    }
    internal class PackageSlipDetails
    {
        public int id { get; set; }
        public string Description { get; set; }
        public int AgentId { get; set; }
    }
    internal class DuplicatePackageSlipDetails
    {
        public int id { get; set; }
        public string Description { get; set; }
        public int AgentId { get; set; }
    }

    internal class MembershipDetails
    {
        public int ID { get; set; }
        public string MemberName { get; set; }
        public bool ReActivation { get; set; }
        public double fees { get; set;}
        public DateTime ExpiryDate { get; set; }
    }
    internal class UserInput
    {
        public string  Type { get; set; }
        public int Id { get; set; }
    }
}
