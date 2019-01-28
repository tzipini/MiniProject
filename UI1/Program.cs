using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;

namespace UI1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BLClass blc = new BLClass();
            Employee em = new Employee();
            Employer emp = new Employer();
            Contract con = new Contract();
            Specialization sp = new Specialization();
            int choice = 0;
            do
            {
                Console.WriteLine("enter 1 to add employee");
                Console.WriteLine("enter 2 to add employer");
                Console.WriteLine("enter 3 to add Contract");
                Console.WriteLine("enter 4 to add Specialization");
                Console.WriteLine("enter 5 to get employee details");
                Console.WriteLine("enter 6 to get employer details");
                Console.WriteLine("enter 7 to get contract details");
                Console.WriteLine("enter 8 to get specialization details");
                Console.WriteLine("enter 9 to remove an employee");
                Console.WriteLine("enter 10 to remove an employer");
                Console.WriteLine("enter 11 to remove a contract");
                Console.WriteLine("enter 12 to remove a specialization");
                Console.WriteLine("enter 13 to Update an employee");
                Console.WriteLine("enter 14 to Update an employer");
                Console.WriteLine("enter 15 to Update a contract");
                Console.WriteLine("enter 16 to Update a specialization");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            try
                            {
                                blc.AddEmloyee(em);
                                Console.WriteLine("enter id fname lname birthdate addres phone");
                                em.Id = Convert.ToInt32(Console.ReadLine());
                                em.Fname = Console.ReadLine();
                                em.Lname = Console.ReadLine();
                                em.BirthDate = Convert.ToDateTime(Console.ReadLine());
                                em.Address = Console.ReadLine();
                                em.Phone = Convert.ToInt32(Console.ReadLine());
                                em.IsMilitaryGraduate = true;
                                em.Recommendation = "";
                                em.SpacialityKey = 11111111;
                                em.ExperienceYears = 1;
                                em.DegreeI = Degree.BA;
                                em.BankAccount1 = new BankAccount();
                                BankAccount b = new BankAccount();
                                b.BankKey = 18;
                                b.BranchNumber = 148;
                                b.Town = "bb";
                                em.BankAccount1 = b;
                                em.AccountNumber = 1378969;
                                em.AreaName = Area.GushDan;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                        break;

                    case 2:
                        {
                            try
                            {
                                Console.WriteLine("enter id fname lname addres phone establishmentDate domain company name");
                                emp.Key = Convert.ToInt32(Console.ReadLine());
                                emp.Fname = Console.ReadLine();
                                emp.Lname = Console.ReadLine();
                                emp.Address = Console.ReadLine();
                                emp.Phone = Convert.ToInt32(Console.ReadLine());
                                emp.EstablishmentDate = Convert.ToDateTime(Console.ReadLine());
                                emp.Domain = (NameSpecialty)Enum.Parse(typeof(NameSpecialty), Console.ReadLine());
                                emp.CompanyName = Console.ReadLine();
                                emp.IsIndependent = true;
                                emp.CompanyKey = 234;

                                blc.AddEmloyer(emp);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case 3:
                        {
                            try
                            {
                                Console.WriteLine("enter employerId employeeId hourlyWageBruto numOfHoursToMonth startDate finishDate ");
                                con.EmployerKey = Convert.ToInt32(Console.ReadLine());
                                con.EmployeeId = Convert.ToInt32(Console.ReadLine());
                                con.IsInterviewed = false;
                                con.IsSinged = true;
                                con.HourlyWageBruto = Convert.ToDouble(Console.ReadLine());
                                con.NumOfHoursToMonth = Convert.ToDouble(Console.ReadLine());
                                con.StartDate = Convert.ToDateTime(Console.ReadLine());
                                con.FinishDate = Convert.ToDateTime(Console.ReadLine());
                                blc.AddContract(con);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case 4:
                        {
                            try
                            {
                                Console.WriteLine("enter speciality name and domain minrate max rate ");
                                sp.SpecialtyName = (NameSpecialty)Enum.Parse(typeof(NameSpecialty), Console.ReadLine());
                                sp.Speciality = Console.ReadLine();
                                sp.MinRate = Convert.ToDouble(Console.ReadLine());
                                sp.MaxRate = Convert.ToDouble(Console.ReadLine());

                                blc.AddSpecialization(sp);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 5:
                        {
                            try
                            {
                                Console.WriteLine("please press employee id");
                                Console.WriteLine(blc.GetEmployee(Convert.ToInt32(Console.ReadLine())));
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 6:
                        {
                            try
                            {
                                Console.WriteLine("please press employer id");
                                Console.WriteLine(blc.GetEmployer(Convert.ToInt32(Console.ReadLine())));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 7:
                        {
                            try
                            {
                                Console.WriteLine("please press contract key");
                                Console.WriteLine(blc.GetContract(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 8:
                        {
                            try
                            {
                                Console.WriteLine("please press spacialization key ");
                                Console.WriteLine(blc.GetSpecialization(Convert.ToInt32( Console.ReadLine())));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 9:
                        {
                            try
                            {
                                Console.WriteLine("please press employee id");
                                blc.RemoveEmloyee(blc.GetEmployee(Convert.ToInt32(Console.ReadLine())));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 10:
                        {
                            try
                            {
                                Console.WriteLine("please press employer id");
                                blc.RemoveEmloyer(blc.GetEmployer(Convert.ToInt32(Console.ReadLine())));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 11:
                        {
                            try
                            {
                                Console.WriteLine("please press employee Id && employer Id");
                                blc.RemoveContract(blc.GetContract(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 12:
                        {
                            try
                            {
                                Console.WriteLine("please press spacialization key ");
                                blc.RemoveSpecialization(blc.GetSpecialization(Convert.ToInt32(Console.ReadLine())));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 13:
                        {
                            try
                            {
                                Console.WriteLine("please press employee id");
                                Employee e = blc.GetEmployee(Convert.ToInt32(Console.ReadLine()));
                                Console.WriteLine("enter fname lname birthdate addres phone");
                                e.Fname = Console.ReadLine();
                                e.Lname = Console.ReadLine();
                                e.BirthDate = Convert.ToDateTime(Console.ReadLine());
                                e.Address = Console.ReadLine();
                                e.Phone = Convert.ToInt32(Console.ReadLine());
                                blc.UpdateEmloyee(e);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("the update didn't succeed " +ex.Message );
                            }
                        }
                        break;
                    case 14:
                        {
                            try
                            {
                                Console.WriteLine("please press an employer id");
                                Employer e = blc.GetEmployer(Convert.ToInt32(Console.ReadLine()));
                                Console.WriteLine("enter fname lname address phone estaplishnmet date domain company name");
                                e.Fname = Console.ReadLine();
                                e.Lname = Console.ReadLine();
                                e.Address = Console.ReadLine();
                                e.Phone = Convert.ToInt32(Console.ReadLine());
                                e.EstablishmentDate = Convert.ToDateTime(Console.ReadLine());
                                e.Domain = (NameSpecialty)Enum.Parse(typeof(NameSpecialty), Console.ReadLine());
                                e.CompanyName = Console.ReadLine();
                                blc.UpdateEmloyer(e);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("the update didn't succeed " + ex.Message);
                            }
                        }
                        break;
                    case 15:
                        {
                            try
                            {
                                foreach (var item in blc.SpaciousGroupingBYMonths())
                                {
                                    Console.WriteLine("key: "+item.Key);
                                    foreach (var item1 in item)
                                    {
                                        Console.WriteLine("    Value: "+item1);
                                    }
                                }
                                
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("the number dind't recognize");
                        }
                        break;
                    case 16:
                        {
                            try
                            {
                                Console.WriteLine("please press an specialization key");
                                sp = blc.GetSpecialization(Convert.ToInt32(Console.ReadLine()));
                                Console.WriteLine("enter speciality name and domain minrate max rate ");
                                sp.SpecialtyName = (NameSpecialty)Enum.Parse(typeof(NameSpecialty), Console.ReadLine());
                                sp.Speciality = Console.ReadLine();
                                sp.MinRate = Convert.ToDouble(Console.ReadLine());
                                sp.MaxRate = Convert.ToDouble(Console.ReadLine());
                                blc.UpdateSpecialization(sp);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("the update didn't succeed " + ex.Message);
                            }
                        }break;
                }
            }
            while (choice != 0);

        }
    }
}
