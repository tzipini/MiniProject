using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace EX_DAL
{
    public class Dal_Imp : IDal
    {
        #region Add Functions
        public void AddContract(Contract c)
        {
            if (c.Key != 0)
            {
                if (DataSource.ContractsList.Contains(c))
                    throw new Exception("the current contract has arlready exist");
            }
            else
            {
                if (DataSource.ContractsList.Count == 0)
                    c.Key = 11111111;
                else
                    c.Key = DataSource.ContractsList[DataSource.ContractsList.Count - 1].Key + 1;
            }
            DataSource.ContractsList.Add(c);
        }
        public void AddEmloyee(Employee e)
        {
            foreach (Employee item in DataSource.EmployeesList)
            {
                if (item.Id == e.Id)
                    throw new Exception("the current employee has already exist");
            }
            DataSource.EmployeesList.Add(e);
        }
        public void AddEmloyer(Employer e)
        {
            foreach (Employer item in DataSource.EmployersList)
            {
                if (item.Key == e.Key)
                    throw new Exception("the current employee has already exist");
            }
            DataSource.EmployersList.Add(e);
        }
        public void AddSpecialization(Specialization s)
        {
            if (s.Key != 0)
            {
                if (DataSource.SpecializationList.Contains(s))
                    throw new Exception("the current spacialization has arlready exist");
            }
            else
            {
                if (DataSource.SpecializationList.Count == 0)
                    s.Key = 11111111;
                else
                    s.Key = DataSource.SpecializationList[DataSource.SpecializationList.Count - 1].Key + 1;
            }
            DataSource.SpecializationList.Add(s);
        }
        #endregion

        #region Get Functions
        public List<BankAccount> getAllBranches()
        {
            List<BankAccount> li = new List<BankAccount>(5);
            return li;
        }

        public List<Contract> getAllContract()
        {
            return DataSource.ContractsList;
        }

        public List<Employee> getAllEmloyees()
        {
            return DataSource.EmployeesList;
        }

        public List<Employer> getAllEmloyers()
        {
            return DataSource.EmployersList;
        }

        public List<Specialization> getAllSpecializations()
        {
            return DataSource.SpecializationList;
        }
        #endregion

        #region Remove Functions
        public void RemoveContract(Contract c)
        {
            foreach (Contract item in DataSource.ContractsList)
            {
                if (item.Key == c.Key)
                {
                    DataSource.ContractsList.Remove(c);
                    return;
                }
            }
            throw new Exception("the current Contract doesn't exist");
        }

        public void RemoveEmloyee(Employee e)
        {
            foreach (Employee item in DataSource.EmployeesList)
            {
                if (item.Id == e.Id)
                {
                    DataSource.EmployeesList.Remove(e);
                    return;
                }

            }
            throw new Exception("the current Employee doesn't exist");
        }

        public void RemoveEmloyer(Employer e)
        {
            foreach (Employer item in DataSource.EmployersList)
            {
                if (item.Key == e.Key)
                {
                    DataSource.EmployersList.Remove(e);
                    return;
                }
            }
            throw new Exception("the current Employer doesn't exist");
        }

        public void RemoveSpecialization(Specialization s)
        {
            foreach (Specialization item in DataSource.SpecializationList)
            {
                if (item.Key == s.Key)
                {
                    DataSource.SpecializationList.Remove(s);
                    return;
                }
                
            }
            throw new Exception("the current Specialization doesn't exist");
        }
        #endregion

        #region Update Functions
        public void UpdateContract(Contract c)
        {
            int index = DataSource.ContractsList.FindIndex(i => c.Key == i.Key);
            if (index != -1)
                DataSource.ContractsList.Insert(index, c);
            else
                throw new Exception("the current Contract doesn't exist");
        }

        public void UpdateEmloyee(Employee e)
        {
            int index = DataSource.EmployeesList.FindIndex(i => e.Id == i.Id);
            if (index != -1)
                DataSource.EmployeesList.Insert(index, e);
            else
                throw new Exception("the current Employee doesn't exist");
        }

        public void UpdateEmloyer(Employer e)
        {
            int index = DataSource.EmployersList.FindIndex(i => e.Key == i.Key);
            if (index != -1)
                DataSource.EmployersList.Insert(index, e);
            else
                throw new Exception("the current Employer doesn't exist");
        }

        public void UpdateSpecialization(Specialization s)
        {
            int index = DataSource.SpecializationList.FindIndex(i => s.Key == i.Key);
            if (index != -1)
                DataSource.SpecializationList.Insert(index, s);
            else
                throw new Exception("the current Specialization doesn't exist");
        }
        #endregion

    }
}
