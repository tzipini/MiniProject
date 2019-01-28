using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Net;

namespace EX_DAL
{
    class DAL_IMP_XML : IDal
    {
        #region files
        static string ContractXml = @"ContractXml.xml";
        static string EmployeeXml = @"EmployeeXml.xml";
        static string EmployerXml = @"EmployerXml.xml";
        static string SpecializationXml = @"SpacializationXml.xml";
        static string BankAccountXml = @"BankAccountXml.xml";
        static XElement contracts;
        static XElement employees;
        static XElement employers;
        static XElement spacializations;
        static XElement bankAccounts;
        #endregion
        public DAL_IMP_XML()
        {
            if (!File.Exists(ContractXml))
            {
                contracts = new XElement("Contracts");
                contracts.Save(ContractXml);
            }
            else
            {
                try
                {
                    contracts = new XElement(XElement.Load(ContractXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(EmployeeXml))
            {
                employees = new XElement("Employees");
                employees.Save(EmployeeXml);
            }
            else
            {
                try
                {
                    employees = new XElement(XElement.Load(EmployeeXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(EmployerXml))
            {
                employers = new XElement("Employers");
                employers.Save(EmployerXml);
            }
            else
            {
                try
                {
                    employers = new XElement(XElement.Load(EmployerXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(SpecializationXml))
            {
                spacializations = new XElement("Spacializations");
                spacializations.Save(SpecializationXml);
            }
            else
            {
                try
                {
                    spacializations = new XElement(XElement.Load(SpecializationXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(BankAccountXml))
            {
                WebClient wc = new WebClient();
                try
                {
                    string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                    wc.DownloadFile(xmlServerPath, BankAccountXml);

                }
                catch (Exception)
                {
                    string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                    wc.DownloadFile(xmlServerPath, BankAccountXml);
                }
                finally
                {
                    wc.Dispose();
                }
            }
            else
            {
                try
                {
                    bankAccounts = new XElement(XElement.Load(BankAccountXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
        }

        #region Build XElement
        XElement BuildXelementContract(Contract c)
        {
            XElement Key = new XElement("Key", c.Key);
            XElement EmployerKey = new XElement("EmployerKey", c.EmployerKey);
            XElement EmployeeId = new XElement("EmployeeId", c.EmployeeId);
            XElement IsInterviewed = new XElement("IsInterviewed", c.IsInterviewed);
            XElement IsSinged = new XElement("IsSinged", c.IsSinged);
            XElement HourlyWageBruto = new XElement("HourlyWageBruto", c.HourlyWageBruto);
            XElement HourlyWageNeto = new XElement("HourlyWageNeto", c.HourlyWageNeto);
            XElement StartDate = new XElement("StartDate", c.StartDate);
            XElement FinishDate = new XElement("FinishDate", c.FinishDate);
            XElement NumOfHoursToMonth = new XElement("NumOfHoursToMonth", c.NumOfHoursToMonth);
            return new XElement("Contract", Key, EmployerKey, EmployeeId, IsInterviewed, IsSinged, HourlyWageBruto, HourlyWageNeto, StartDate, FinishDate, NumOfHoursToMonth);
        }
        XElement BuildXelementEmployee(Employee e)
        {
            XElement ID = new XElement("Id", e.Id);
            XElement Fname = new XElement("Fname", e.Fname);
            XElement Lname = new XElement("Lname", e.Lname);
            XElement BirthDate = new XElement("BirthDate", e.BirthDate);
            XElement Phone = new XElement("Phone", e.Phone);
            XElement Address = new XElement("Address", e.Address);
            XElement AreaName = new XElement("AreaName", e.AreaName);
            XElement DegreeI = new XElement("DegreeI", e.DegreeI);
            XElement IsMilitaryGraduate = new XElement("IsMilitaryGraduate", e.IsMilitaryGraduate);
            XElement Recommendation = new XElement("Recommendation", e.Recommendation);
            XElement ExperienceYears = new XElement("ExperienceYears", e.ExperienceYears);
            XElement BankKey = new XElement("BankKey", e.BankAccount1.BankKey);
            XElement BranchNumber = new XElement("BranchNumber", e.BankAccount1.BranchNumber);
            XElement Town = new XElement("Town",e.BankAccount1.Town);
            XElement BankName = new XElement("BankName", e.BankAccount1.BankName);
            XElement BankAccount1 = new XElement("BankAccount", BankName, BranchNumber, Town);
            XElement AccountNuber = new XElement("AccountNumber", e.AccountNumber);
            XElement SpacialityKey = new XElement("SpacialityKey", e.SpacialityKey);
            return new XElement("Employee", ID, Fname, Lname, BirthDate, Phone, Address, AreaName, DegreeI, IsMilitaryGraduate, Recommendation, ExperienceYears, BankAccount1, AccountNuber, SpacialityKey);
        }
        XElement BuildXelementEmployer(Employer e)
        {
            XElement Key = new XElement("Key", e.Key);
            XElement IsIndependent = new XElement("IsIndependent", e.IsIndependent);
            XElement CompanyKey = new XElement("CompanyKey", e.CompanyKey);
            XElement Lname = new XElement("Lname", e.Lname);
            XElement Fname = new XElement("Fname", e.Fname);
            XElement CompanyName = new XElement("CompanyName", e.CompanyName);
            XElement Phone = new XElement("Phone", e.Phone);
            XElement Address = new XElement("Address", e.Address);
            XElement Domain = new XElement("Domain", e.Domain);
            XElement EstablishmentDate = new XElement("EstablishmentDate", e.EstablishmentDate);
            return new XElement("Employer", Key, IsIndependent, CompanyKey, Lname, Fname, CompanyName, Phone, Address, Domain, EstablishmentDate);
        }
        XElement BuildXelementSpecialization(Specialization s)
        {
            XElement Key = new XElement("Key", s.Key);
            XElement SpecialtyName = new XElement("SpecialtyName", s.SpecialtyName);
            XElement Speciality = new XElement("Speciality", s.Speciality);
            XElement MinRate = new XElement("MinRate", s.MinRate);
            XElement MaxRate = new XElement("MaxRate", s.MaxRate);
            return new XElement("Specialization", Key, SpecialtyName, Speciality, MinRate, MaxRate);
        }
        #endregion

        #region Build Object
        Contract BuildContract(XElement xc)
        {
            Contract c = new Contract();
            c.Key = Convert.ToInt32(xc.Element("Key").Value);
            c.EmployerKey = Convert.ToInt32(xc.Element("EmployerKey").Value);
            c.EmployeeId = Convert.ToInt32(xc.Element("EmployeeId").Value);
            c.IsInterviewed = Convert.ToBoolean(xc.Element("IsInterviewed").Value);
            c.IsSinged = Convert.ToBoolean(xc.Element("IsSinged ").Value);
            c.HourlyWageBruto = Convert.ToDouble(xc.Element("HourlyWageBruto").Value);
            c.HourlyWageNeto = Convert.ToDouble(xc.Element("HourlyWageNeto").Value);
            c.StartDate = Convert.ToDateTime(xc.Element("StartDate").Value);
            c.FinishDate = Convert.ToDateTime(xc.Element("FinishDate").Value);
            c.NumOfHoursToMonth = Convert.ToDouble(xc.Element("NumOfHoursToMonth").Value);
            return c;
        }
        Employee BuildEmployee(XElement xe)
        {
            Employee e = new Employee();
            e.Id = Convert.ToInt32(xe.Element("Id").Value);
            e.Fname = xe.Element("Fname").Value;
            e.Lname = xe.Element("Lname").Value;
            e.BirthDate = Convert.ToDateTime(xe.Element("BirthDate").Value);
            e.Phone = Convert.ToInt32(xe.Element("Phone").Value);
            e.Address = xe.Element("Address").Value;
            e.AreaName = (Area)Enum.Parse(typeof(Area), xe.Element("AreaName").Value);
            e.DegreeI = (Degree)Enum.Parse(typeof(Degree), xe.Element("DegreeI").Value);
            e.IsMilitaryGraduate = Convert.ToBoolean(xe.Element("IsMilitaryGraduate").Value);
            e.Recommendation = xe.Element("Recommendation").Value;
            e.ExperienceYears = Convert.ToDouble(xe.Element("ExperienceYears").Value);
            BankAccount t = new BankAccount();
            t.BankKey = Convert.ToInt32(xe.Element("BankAccount").Element("BankKey").Value);
            t.BankName = xe.Element("BankAccount").Element("BankName").Value;
            t.BranchNumber = Convert.ToInt32(xe.Element("BankAccount1").Element("BranchNumber").Value);
            t.Town = xe.Element("BankAccount1").Element("Town").Value;
            e.BankAccount1 = t;
            e.AccountNumber = Convert.ToInt32(xe.Element("AccountNumber").Value);
            e.SpacialityKey = Convert.ToInt32(xe.Element("SpacialityKey").Value);
            return e;
        }
        Employer BuildEmployer(XElement xe)
        {
            Employer e = new Employer();
            e.Key = Convert.ToInt32(xe.Element("Key").Value);
            e.IsIndependent = Convert.ToBoolean(xe.Element("IsIndependent").Value);
            e.CompanyKey = Convert.ToInt32(xe.Element("CompanyKey").Value);
            e.Lname = xe.Element("Lname").Value;
            e.Fname = xe.Element("Fname").Value;
            e.CompanyKey = Convert.ToInt32(xe.Element("CompanyKey").Value);
            e.Phone = Convert.ToInt32(xe.Element("Phone").Value);
            e.Address = xe.Element("Address").Value;
            e.Domain = (NameSpecialty)Enum.Parse(typeof(NameSpecialty), xe.Element("Domain").Value);
            e.EstablishmentDate = Convert.ToDateTime(xe.Element("EstablishmentDate").Value);
            return e;
        }
        BankAccount BuildBankAccount(XElement xe)
        {
            BankAccount ba = new BankAccount();
            ba.BankName = xe.Element("שם_בנק").Value;
            ba.BankKey = Convert.ToInt32(xe.Element("קוד_בנק").Value);
            ba.BranchNumber = Convert.ToInt32(xe.Element("קוד_סניף").Value);
            ba.Town = xe.Element("ישוב").Value;
            return ba;
        }
        Specialization BuildSpacialization(XElement xe)
        {
            Specialization s = new Specialization();
            s.Key = Convert.ToInt32(xe.Element("Key").Value);
            s.SpecialtyName = (NameSpecialty)Enum.Parse(typeof(NameSpecialty), xe.Element("SpecialtyName").Value);
            s.Speciality = xe.Element("Speciality").Value;
            s.MinRate = Convert.ToDouble(xe.Element("MinRate").Value);
            s.MaxRate = Convert.ToDouble(xe.Element("MaxRate").Value);
            return s;
        }
        #endregion

        #region Add Functions
        public void AddContract(Contract c)
        {
            List<Contract> li = this.getAllContract();
            if (c.Key != 0)
            {
                foreach (var item in li)
                {
                    if (item.Key == c.Key)
                        throw new Exception("the current contract alredy exist");
                }
            }
            if (li.Count == 0)
                c.Key = 10000000;
            else
                c.Key = li[li.Count - 1].Key + 1;

            contracts.Add(BuildXelementContract(c));
            contracts.Save(ContractXml);
        }

        public void AddEmloyee(Employee e)
        {
            foreach(var item in getAllEmloyees())
            {
                if (item.Id == e.Id)
                    throw new Exception("the current employee alredy exist");
            }
            employees.Add(BuildXelementEmployee(e));
            employees.Save(EmployeeXml);
        }

        public void AddEmloyer(Employer e)
        {
            foreach (var item in getAllEmloyers())
            {
                if (item.Key == e.Key)
                    throw new Exception("the current employee alredy exist");
            }
            employers.Add(BuildXelementEmployer(e));
            employers.Save(EmployerXml);
        }

        public void AddSpecialization(Specialization s)
        {
            List<Specialization> li = this.getAllSpecializations();
            if (s.Key != 0)
            {
                foreach (var item in li)
                {
                    if (item.Key == s.Key)
                        throw new Exception("the current specialization alredy exist");
                }
            }
            if (li.Count == 0)
                s.Key = 10000000;
            else
                s.Key = li[li.Count - 1].Key + 1;

            spacializations.Add(BuildXelementSpecialization(s));
            spacializations.Save(SpecializationXml);
        }
        #endregion

        #region Get Functions
        public List<BankAccount> getAllBranches()
        {
            return (from v in bankAccounts.Elements()
                    select BuildBankAccount(v)).ToList();
        }

        public List<Contract> getAllContract()
        {
            return (from v in contracts.Elements()
                    select BuildContract(v)).ToList();      
        }

        public List<Employee> getAllEmloyees()
        {
            return (from v in employees.Elements()
                    select BuildEmployee(v)).ToList();
        }

        public List<Employer> getAllEmloyers()
        {
            return (from v in employers.Elements()
                    select BuildEmployer(v)).ToList();
        }

        public List<Specialization> getAllSpecializations()
        {
            return (from v in spacializations.Elements()
                    select BuildSpacialization(v)).ToList();
        }
        #endregion

        #region Remove Functions
        public void RemoveContract(Contract c)
        {
            XElement current = (from x in contracts.Elements()
                                where Convert.ToInt32(x.Element("Key").Value) == c.Key
                                select x).FirstOrDefault();
            current.Remove();
            contracts.Save(ContractXml);
        }

        public void RemoveEmloyee(Employee e)
        {
            XElement current = (from x in employees.Elements()
                                where Convert.ToInt32(x.Element("Id").Value) == e.Id
                                select x).FirstOrDefault();
            current.Remove();
            employees.Save(EmployeeXml);
        }

        public void RemoveEmloyer(Employer e)
        {
            XElement current = (from x in employers.Elements()
                                where Convert.ToInt32(x.Element("Key").Value) == e.Key
                                select x).FirstOrDefault();
            current.Remove();
            employers.Save(EmployerXml);
        }

        public void RemoveSpecialization(Specialization s)
        {
            XElement current = (from x in spacializations.Elements()
                                where Convert.ToInt32(x.Element("Key").Value) == s.Key
                                select x).FirstOrDefault();
            current.Remove();
            spacializations.Save(SpecializationXml);
        }
        #endregion

        #region Update Functions
        public void UpdateContract(Contract c)
        {
            XElement current = (from x in contracts.Elements()
                                where x.Element("Key").Value == Convert.ToString(c.Key)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current contract doesn't exist");
            current.Element("EmployerKey").Value = Convert.ToString(c.EmployerKey);
            current.Element("EmployeeId").Value = Convert.ToString(c.EmployeeId);
            current.Element("IsInterviewed").Value = Convert.ToString(c.IsInterviewed);
            current.Element("IsSinged").Value = Convert.ToString(c.IsSinged);
            current.Element("HourlyWageBruto").Value = Convert.ToString( c.HourlyWageBruto);
            current.Element("HourlyWageNeto").Value = Convert.ToString(c.HourlyWageNeto);
            current.Element("StartDate").Value = Convert.ToString( c.StartDate);
            current.Element("FinishDate").Value = Convert.ToString( c.FinishDate);
            current.Element("NumOfHoursToMonth").Value = Convert.ToString( c.NumOfHoursToMonth);
            contracts.Save(ContractXml);

        }

        public void UpdateEmloyee(Employee e)
        {
            XElement current = (from x in employees.Elements()
                                where x.Element("Id").Value == Convert.ToString(e.Id)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current employee doesn't exist");
            current.Element("Fname").Value = e.Fname;
            current.Element("Lname").Value = e.Lname;
            current.Element("BirthDate").Value = Convert.ToString(e.BirthDate);
            current.Element("Phone").Value = Convert.ToString(e.Phone);
            current.Element("Address").Value = e.Address;
            current.Element("AreaName").Value = Convert.ToString( e.AreaName);
            current.Element("DegreeI").Value = Convert.ToString(e.DegreeI);
            current.Element("IsMilitaryGraduate").Value = Convert.ToString(e.IsMilitaryGraduate);
            current.Element("Recommendation").Value = e.Recommendation;
            current.Element("ExperienceYears").Value = Convert.ToString(e.ExperienceYears);
            current.Element("BankAccount").Element("BankKey").Value = Convert.ToString(e.BankAccount1.BankKey);
            current.Element("BankAccount").Element("BankName").Value = e.BankAccount1.BankName;
            current.Element("BankAccount").Element("Town").Value = e.BankAccount1.Town;
            current.Element("BankAccount").Element("BranchNumber").Value = Convert.ToString(e.BankAccount1.BranchNumber);
            current.Element("AccountNuber").Value = Convert.ToString(e.AccountNumber);
            current.Element("SpacialityKey").Value = Convert.ToString(e.SpacialityKey);
            employees.Save(EmployeeXml);
        }

        public void UpdateEmloyer(Employer e)
        {
            XElement current = (from x in contracts.Elements()
                                where x.Element("Key").Value == Convert.ToString(e.Key)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current employer doesn't exist");
            current.Element("IsIndependent").Value = Convert.ToString(e.IsIndependent);
            current.Element("CompanyKey").Value = Convert.ToString(e.CompanyKey);
            current.Element("Lname").Value =  e.Lname;
            current.Element("Fname").Value = e.Fname;
            current.Element("CompanyName").Value = e.CompanyName;
            current.Element("Phone").Value = Convert.ToString(e.Phone);
            current.Element("Address").Value = e.Address;
            current.Element("Domain").Value = Convert.ToString(e.Domain);
            current.Element("EstablishmentDate").Value = Convert.ToString(e.EstablishmentDate);
            employers.Save(EmployerXml);
        }

        public void UpdateSpecialization(Specialization s)
        {
            XElement current = (from x in spacializations.Elements()
                                where x.Element("Key").Value == Convert.ToString(s.Key)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current specialization doesn't exist");
            current.Element("SpecialtyName").Value = Convert.ToString(s.SpecialtyName);
            current.Element("Speciality").Value = s.Speciality;
            current.Element("MinRate").Value =  Convert.ToString( s.MinRate);
            current.Element("MaxRate").Value = Convert.ToString( s.MaxRate);
            spacializations.Save(SpecializationXml );
        }
        #endregion
    }
}
