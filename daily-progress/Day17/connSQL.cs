using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SqlConn
{
    internal class Program
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            InsertData();
            DeleteData();
            SelectData();
            SelectionWithCondition();
            UpdateData();
            CountEmployees();
            Console.Read();
        }

        public static SqlConnection getConnection()
        {
            con = new SqlConnection("data source = RYZEN5\\SQLEXPRESS;initial catalog = assignment;integrated security = true;");
            con.Open();
            return con;
        }

        public static void SelectData()
        {
            con = getConnection();
            cmd = new SqlCommand("select * from emp", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " " + dr[1]);
                Console.WriteLine("Employee Number = " + dr["empno"]);
                Console.WriteLine("Employee Name = " + dr["ename"]);
                Console.WriteLine("Employee Job = " + dr[2]);
                Console.WriteLine("Manager ID = " + dr["mgr_id"]);
                Console.WriteLine("Employee Salary = " + dr[5]);
            }
        }

        public static void SelectionWithCondition()
        {
            con = getConnection();

            StringBuilder sbq = new StringBuilder();
            sbq.Append("select * from emp ")
                .Append("where ");
            sbq.Append("sal > 2000 ");

            string selectquery = sbq.ToString();
            cmd = new SqlCommand(selectquery);
            cmd.Connection = con;

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr["Empno"]}, {dr["Ename"]},{dr["sal"]} ");
            }
        }

        public static void InsertData()
        {
            con = getConnection();
            int eid, deptid;
            string ename, job;
            decimal sal;
            DateOnly hd;

            Console.WriteLine("Enter Eid :");
            eid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name :");
            ename = Console.ReadLine();
            Console.WriteLine("Enter Job :");
            job = Console.ReadLine();
            Console.WriteLine("Enter Year Month and Date of HireDate :");
            int yy = Convert.ToInt32(Console.ReadLine());
            int mm = Convert.ToInt32(Console.ReadLine());
            int dd = Convert.ToInt32(Console.ReadLine());
            hd = new DateOnly(yy, mm, dd);

            DateTime dt = hd.ToDateTime(TimeOnly.MinValue);
            Console.WriteLine("Enter Salary :");
            sal = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter dept :");
            deptid = Convert.ToInt32(Console.ReadLine());

            cmd = new SqlCommand("insert into emp(empno,ename,job,hire_date,sal,deptno) values(@ecode,@name,@job,@hd,@salary,@did)", con);

            cmd.Parameters.AddWithValue("ecode", eid);
            cmd.Parameters.AddWithValue("name", ename);
            cmd.Parameters.AddWithValue("job", job);
            cmd.Parameters.AddWithValue("hd", dt);
            cmd.Parameters.AddWithValue("salary", sal);
            cmd.Parameters.AddWithValue("did", deptid);

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                Console.WriteLine("Record added successfully..");
            }
            else
                Console.WriteLine("Unable to add a record ..");
        }
        public static void CountEmployees()
        {
            con = getConnection();
            cmd = new SqlCommand("SELECT COUNT(Empno) FROM Employees", con);
            int count = (int)cmd.ExecuteScalar();
            Console.WriteLine("Total number of employees: " + count);
        }

        public static void UpdateData()
        {
            con = getConnection();
            Console.WriteLine("Enter Employee Number to update:");
            int Empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Salary:");
            decimal newSalary = Convert.ToDecimal(Console.ReadLine());

            cmd = new SqlCommand("update Employees set Salary = @salary where Empno = @empno", con);
            cmd.Parameters.AddWithValue("@salary", newSalary);
            cmd.Parameters.AddWithValue("@empno", Empno);

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                Console.WriteLine("Record updated successfully..");
            }
            else
                Console.WriteLine("No record found with the given Employee Number.");
        }

        static void DeleteData()
        {
            con = getConnection();
            Console.WriteLine("enter the empno to delete :");
            int empno = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd1 = new SqlCommand("select * from emp where empno = @eno", con);
            cmd1.Parameters.AddWithValue("@eno", empno);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                for (int i = 0; i < dr1.FieldCount; i++)
                {
                    Console.WriteLine(dr1[i]);
                }
            }
            con.Close();
        }
    }
}
