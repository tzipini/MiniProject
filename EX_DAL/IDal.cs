using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace EX_DAL
{
    public interface IDal
    {
        #region Specilaization
        /// <summary>
        /// The function AddSpecialization get a specialization to add to the Data - Source.
        /// </summary>
        /// <param name="specialization"></param>
        void AddSpecialization(Specialization s);
        /// <summary>
        /// The function UpdateSpecialization get a existing specialization  to add to the Data - Source.
        /// </summary>
        /// <param name="specialization"></param>
        void UpdateSpecialization(Specialization s);
        /// <summary>
        /// The function RemoveSpecialization get a existing specialization and remove it from the Data Source.
        /// </summary>
        /// <param name="specialization"></param>
        void RemoveSpecialization(Specialization s);
        /// <summary>
        /// The function getAllSpecializations returns a Ienumerable of Specializations from the data source.
        /// </summary>
        /// <returns></returns>
        List<Specialization> getAllSpecializations();
        #endregion

        #region Employee
        /// <summary>
        /// The function AddEmplyee get an employee to add to the Data - Source.
        /// </summary>
        /// <param name="employee"></param>
        void AddEmloyee(Employee e);
        /// <summary>
        /// The function UpdateEmployee get an existing employee  to add to the Data - Source.
        /// </summary>
        /// <param name="Employee"></param>
        void UpdateEmloyee(Employee e);
        /// <summary>
        /// The function RemoveEmployee get an existing emplyee and remove it from the Data Source.
        /// </summary>
        /// <param name="employee"></param>
        void RemoveEmloyee(Employee e);
        /// <summary>
        /// The function getAllEmployees returns a Ienumerable of employees from the data source.
        /// </summary>
        /// <returns></returns>
        List<Employee> getAllEmloyees();
        #endregion

        #region Employer
        /// <summary>
        /// The function AddEmplyer get an employer to add to the Data - Source.
        /// </summary>
        /// <param name="employer"></param>
        void AddEmloyer(Employer e);
        /// <summary>
        /// The function UpdatEmployer get an existing employer  to add to the Data - Source.
        /// </summary>
        /// <param name="employer"></param>
        void UpdateEmloyer(Employer e);
        /// <summary>
        /// The function RemoveEmployer get an existing emplyer and remove it from the Data Source.
        /// </summary>
        /// <param name="employer"></param>
        void RemoveEmloyer(Employer e);
        /// <summary>
        /// The function getAllEmployers returns a Ienumerable of employers from the data source.
        /// </summary>
        /// <returns></returns>
        List<Employer> getAllEmloyers();
        #endregion

        #region Contract
        /// <summary>
        /// The function AddContract get a contract to add to the Data - Source.
        /// </summary>
        /// <param name="contract"></param>
        void AddContract(Contract c);
        /// <summary>
        /// The function UpdateContract get a existing contract  to add to the Data - Source.
        /// </summary>
        /// <param name="contract"></param>
        void UpdateContract(Contract c);
        /// <summary>
        /// The function RemoveContract get a existing contract and remove it from the Data Source.
        /// </summary>
        /// <param name="contract"></param>
        void RemoveContract(Contract c);
        /// <summary>
        /// The function getAllContracts returns a Ienumerable of contracts from the data source.
        /// </summary>
        /// <returns></returns>
        List<Contract> getAllContract();
        #endregion

        List<BankAccount> getAllBranches();

    }
}
