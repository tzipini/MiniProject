using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using EX_DAL;

namespace BL
{
    public class BLClass : IBL
    {
        static  IDal dal = FactoryDal.getDal();

        #region Add Functions
        public void AddContract(Contract c)
        {
            bool id1 = false, id2 = false;
            Employer e = new Employer();
            foreach (Employee item in dal.getAllEmloyees() as List<Employee>)
            {
                if (item.Id == c.EmployeeId)
                    id1 = true;
            }
            foreach (Employer item in dal.getAllEmloyers() as List<Employer>)
            {
                if (item.Key == c.EmployerKey)
                {
                    id2 = true;
                    e = item;
                }
            }
            if (id1 == true && id2 == true && DateTime.Now.getAge(e.EstablishmentDate) >= 1)
            {
                c.HourlyWageNeto = Neto(c);
                c.Key = 0;
                dal.AddContract(c);
            }
            else
                throw new Exception("the contract is not allowed");
        }
        public void AddEmloyee(Employee e)
        {
            if (DateTime.Now.getAge(e.BirthDate) < 18)
                throw new Exception("the employer is too small");
            bool b = false;
            foreach (var item in dal.getAllBranches())
            {
                if (e.BankAccount1.BranchNumber == item.BranchNumber&&e.BankAccount1.BankKey == item.BankKey)
                    b = true;
            }
            if (!b)
                throw new Exception("the details of the bank account is wrong");
            if (!ToolsBL.CheckId(e.Id))
                throw new Exception("the id number is wrong");
            if (!ToolsBL.IsLetters(e.Fname))
                throw new Exception("the first name is not in the correct pattern");
            if (!ToolsBL.IsLetters(e.Lname))
                throw new Exception("the last name is not in the correct pattern");
            if (!ToolsBL.IsCellPhone(Convert.ToString(e.Phone)) && !ToolsBL.IsPhone(Convert.ToString(e.Phone)))
                throw new Exception("the phone number is not in the correct pattern");
            DateTime age = new DateTime(e.BirthDate.Year + 18, e.BirthDate.Month, e.BirthDate.Day);
            if (e.ExperienceYears < 0 || e.ExperienceYears > DateTime.Now.getAge(age))
                throw new Exception("the experience years is uncorrect");
            b = false;
            foreach (var item in dal.getAllSpecializations() as IEnumerable<Specialization>)
            {
                if (item.Key == e.SpacialityKey)
                    b = true;
            }
            if (!b)
                throw new Exception("the spaciality Key dosen't exist");
            dal.AddEmloyee(e);

        }
        public void AddEmloyer(Employer e)
        {
            if (e.IsIndependent)
                if (!ToolsBL.CheckId(e.Key))
                    throw new Exception("the id number is wrong");
            if (!ToolsBL.IsLetters(e.Fname))
                throw new Exception("the first name is not in the correct pattern");
            if (!ToolsBL.IsLetters(e.Lname))
                throw new Exception("the last name is not in the correct pattern");
            if (!ToolsBL.IsCellPhone(Convert.ToString(e.Phone)) && !ToolsBL.IsPhone(Convert.ToString(e.Phone)))
                throw new Exception("the phone number is not in the correct pattern");
            if (e.EstablishmentDate > DateTime.Now)
                throw new Exception("the establishmentDate is uncorrect");
            dal.AddEmloyer(e);
        }
        public void AddSpecialization(Specialization s)
        {
            if (s.MinRate > s.MaxRate || s.MinRate < 25)
                throw new Exception("the minmum rate is wrong");
            s.Key = 0;
            dal.AddSpecialization(s);
        }
        #endregion

        #region Get Functions
        public List<BankAccount> getAllBranches()
        {
            return dal.getAllBranches();
        }
        public List<Contract> getAllContract()
        {
            return dal.getAllContract();
        }
        public List<Employee> getAllEmloyees()
        {
            return dal.getAllEmloyees();
        }
        public List<Employer> getAllEmloyers()
        {
            return dal.getAllEmloyers();
        }
        public List<Specialization> getAllSpecializations()
        {
            return dal.getAllSpecializations();
        }
        public Employee GetEmployee (int id)
        {
            foreach (var item in dal.getAllEmloyees())
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }
        public Employer GetEmployer(int id)
        {
            foreach (var item in dal.getAllEmloyers())
            {
                if (item.Key == id)
                    return item;
            }
            return null;
        }
        public Specialization GetSpecialization(int key)
        {
            foreach (var item in dal.getAllSpecializations())
            {
                if (item.Key == key)
                    return item;
            }
            return null;
        }
        public Contract GetContract(int employeeId,int employerKey)
        {
            foreach (var item in dal.getAllContract())
            {
                if (item.EmployeeId == employeeId && item.EmployerKey == employerKey)
                    return item;
            }
            return null;
        }
        #endregion

        #region Remove Functions
        public void RemoveContract(Contract c)
        {
            dal.RemoveContract(c);
        }
        public void RemoveEmloyee(Employee e)
        {
            dal.RemoveEmloyee(e);
        }
        public void RemoveEmloyer(Employer e)
        {
            dal.RemoveEmloyer(e);
        }
        public void RemoveSpecialization(Specialization s)
        {
            dal.RemoveSpecialization(s);
        }
        #endregion

        #region Update Functions
        public void UpdateContract(Contract c)
        {
            bool id1 = false, id2 = false;
            Employer e = new Employer();
            foreach (Employee item in dal.getAllEmloyees() as List<Employee>)
            {
                if (item.Id == c.EmployeeId)
                    id1 = true;
            }
            foreach (Employer item in dal.getAllEmloyers() as List<Employer>)
            {
                if (item.Key == c.EmployerKey)
                {
                    id2 = true;
                    e = item;
                }
            }
            if (id1 == true && id2 == true && DateTime.Now.getAge(e.EstablishmentDate) >= 1)
            {
                c.HourlyWageNeto = Neto(c);
                dal.UpdateContract(c);
            }
            else
                throw new Exception("the Updated contract is not allowed");
        }
        public void UpdateEmloyee(Employee e)
        {
            if (DateTime.Now.getAge(e.BirthDate) < 18)
                throw new Exception("the employer is too small");
            bool b = false;
            foreach (var item in dal.getAllBranches())
            {
                if (e.BankAccount1.BranchNumber == item.BranchNumber && e.BankAccount1.BankKey == item.BankKey)
                    b = true;
            }
            if (!b)
                throw new Exception("the details of the bank account is wrong");
            if (!ToolsBL.IsLetters(e.Fname))
                throw new Exception("the first name is not in the correct pattern");
            if (!ToolsBL.IsLetters(e.Lname))
                throw new Exception("the last name is not in the correct pattern");
            if (!ToolsBL.IsCellPhone(Convert.ToString(e.Phone)) && !ToolsBL.IsPhone(Convert.ToString(e.Phone)))
                throw new Exception("the phone number is not in the correct pattern");
            DateTime age = new DateTime(e.BirthDate.Year + 18, e.BirthDate.Month, e.BirthDate.Day);
            if (e.ExperienceYears < 0 || e.ExperienceYears > DateTime.Now.getAge(age))
                throw new Exception("the experience years is uncorrect");
            b = false;
            foreach (var item in dal.getAllSpecializations() as IEnumerable<Specialization>)
            {
                if (item.Key == e.SpacialityKey)
                    b = true;
            }
            if (!b)
                throw new Exception("the spaciality Key dosen't exist");
            dal.UpdateEmloyee(e);
        }
        public void UpdateEmloyer(Employer e)
        {
            if (!ToolsBL.IsLetters(e.Fname))
                throw new Exception("the first name is not in the correct pattern");
            if (!ToolsBL.IsLetters(e.Lname))
                throw new Exception("the last name is not in the correct pattern");
            if (!ToolsBL.IsCellPhone(Convert.ToString(e.Phone)) && !ToolsBL.IsPhone(Convert.ToString(e.Phone)))
                throw new Exception("the phone number is not in the correct pattern");
            if (e.EstablishmentDate > DateTime.Now)
                throw new Exception("the establishmentDate is uncorrect");
            dal.UpdateEmloyer(e);
        }
        public void UpdateSpecialization(Specialization s)
        {
            if (s.MinRate > s.MaxRate || s.MinRate < 25)
                throw new Exception("the minmum rate is wrong");
            dal.UpdateSpecialization(s);
        }
        #endregion

        #region Utlities Functions
        double Neto(Contract e)
        {
            int j = GetAllContractToEmployer(e.EmployerKey).Count;
            int i = GetAllContractToEmployee(e.EmployeeId).Count;
            return e.HourlyWageBruto * (0.8 + (i + j) * 0.5);
        }
        List<Contract> GetSpeciphicContracts(Func<Contract, bool> condition)
        {
            return (dal.getAllContract() as IEnumerable<Contract>).Where(condition).ToList();
        }
        int NumOfSpeciphicCOntacts(Func<Contract, bool> condition)
        {
            return GetSpeciphicContracts(condition).Count();
        }
        /// <summary>
        /// The function GetAllEmployeeWith get a function that get employee and return True/False.
        /// The function GetAllEmployeeWith return an Ienumerable of employees whith the employees that meet the condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        List<Employee> GetAllEmployeeWithCondition (Predicate<Employee> condition)
        {
            return (from Employee e in dal.getAllEmloyees()
                    where condition(e) == true
                    select e).ToList();
        }
        #endregion

        #region Grouping Functions

        public IEnumerable<IGrouping<int, Contract>> ContractsGroupingBYSpeciality(bool isSorted = false)
        {
            if (isSorted == true)
            {
                var v = from Contract c in dal.getAllContract() as IEnumerable<Contract>
                        from Employee e in dal.getAllEmloyees() as IEnumerable<Employee>
                        where c.EmployeeId == e.Id
                        orderby c.Key
                        group c by e.SpacialityKey;
                return v;
            }
            var x = from Contract c in dal.getAllContract() as IEnumerable<Contract>
                    from Employee e in dal.getAllEmloyees() as IEnumerable<Employee>
                    where c.EmployeeId == e.Id
                    group c by e.SpacialityKey;
            return x;

        }
        public IEnumerable<IGrouping<Area, Contract>> ContractsGroupingBYArea(bool isSorted = false)
        {
            if (isSorted == true)
            {
                var v = from Contract c in dal.getAllContract() as IEnumerable<Contract>
                        from Employee e in dal.getAllEmloyees() as IEnumerable<Employee>
                        where c.EmployeeId == e.Id
                        orderby c.Key
                        group c by e.AreaName;
                return v;
            }
            var x = from Contract c in dal.getAllContract() as IEnumerable<Contract>
                    from Employee e in dal.getAllEmloyees() as IEnumerable<Employee>
                    where c.EmployeeId == e.Id
                    group c by e.AreaName;
            return x;

        }
        public IEnumerable<IGrouping<int, double>> SpaciousGroupingBYMonths(bool isSorted = false)
        {
            if (isSorted == true)
            {
                var v = (from Contract c in dal.getAllContract()
                        let sum = c.NumOfHoursToMonth * c.HourlyWageBruto
                        orderby c.StartDate.Day
                        group sum by c.StartDate.Month).ToList();

                foreach (var item in v)
                {
                    double sum = 0;
                    foreach (var item1 in item)
                    {
                        sum += item1;
                    }
                    int key = item.Key;
                    v.Remove(item);
                    var c = new[] { sum }.GroupBy(y => key).Single();
                    v.Add(c);
                }
                return v;
   
            }
            var x = (from Contract c in dal.getAllContract() as IEnumerable<Contract>
                    let sum = c.NumOfHoursToMonth * c.HourlyWageBruto
                    group sum by c.StartDate.Month).ToList();
            foreach (var item in x)
            {
                double sum = 0;
                foreach (var item1 in item)
                {
                    sum += item1;
                }
                int key = item.Key;
                x.Remove(item);
                var c = new[] { sum }.GroupBy(y => key).Single();
                x.Add(c);
            }
            return x;
        }
        public IEnumerable<IGrouping<bool, Employer>> EmployersGroupingBYDependent(bool isSordted = false)
        {
            if (isSordted)
            {
                return from Employer e in dal.getAllEmloyers() as IEnumerable<Employer>
                       orderby e.Key
                       group e by e.IsIndependent;
            }
            return from Employer e in dal.getAllEmloyers() as IEnumerable<Employer>
                   group e by e.IsIndependent;
        }
        public IEnumerable<IGrouping<Degree, Employee>> EmployeesGroupingByDegree(bool isSorted = false)
        {
            if (isSorted)
            {
                return from Employee e in dal.getAllEmloyees() as IEnumerable<Employee>
                       orderby e.Id
                       group e by e.DegreeI;
            }
            return from Employee e in dal.getAllEmloyees() as IEnumerable<Employee>
                   group e by e.DegreeI;
        }
        #endregion

        #region Creative Functions

        List<Contract> GetAllContractToEmployee(int id)
        {
            List<Contract> lid = new List<Contract>();
            foreach (var item in dal.getAllContract() as IEnumerable<Contract>)
            {
                if (item.EmployeeId == id)
                    lid.Add(item);
            }
            return lid;
        }
        List<Contract> GetAllContractToEmployer(int id)
        {
            List<Contract> lid = new List<Contract>();
            foreach (var item in dal.getAllContract() as IEnumerable<Contract>)
            {
                if (item.EmployeeId == id)
                    lid.Add(item);
            }
            return lid;
        }
        double AverageOfNetoWage()
        {
            return (dal.getAllContract() as IEnumerable<Contract>).Average<Contract>(a => a.HourlyWageNeto);
        }
        int GetTheEmployerWithMostDealsNUM()
        {
            return (dal.getAllEmloyers().Select(x => GetAllContractToEmployer(x.Key).Count)).Max();
        }
        Employer GetTheEmployerWithMostDeals()
        {
            int maxNumber = GetTheEmployerWithMostDealsNUM();
            return dal.getAllEmloyers().Where(x => GetAllContractToEmployer(x.Key).Count == maxNumber).FirstOrDefault();
        }
        IEnumerable<Employee> GetAllEmployeesWitheGivenSpecialization(Specialization s)
        {
            return from Employee e in dal.getAllEmloyees() as IEnumerable<Employee>
                   where e.SpacialityKey == s.Key
                   select e;
        }

        #endregion
    }
}
