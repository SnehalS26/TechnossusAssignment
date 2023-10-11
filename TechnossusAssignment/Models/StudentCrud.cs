
using System.Data.SqlClient;

namespace TechnossusAssignment.Models
{
    public class StudentCrud
    {
        IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public StudentCrud(IConfiguration configure)
        {
            this.configuration = configure;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }        
        public IEnumerable<Student> GetAllStudents(string searchString , DateTime? registrationDate)
        {
            List<Student> list = new List<Student> ();
            string qry = "select * from Student Where (address Like @searchString OR stud_name Like @searchString) and isActive = 1";
            if(registrationDate.HasValue)
            {
                qry += "AND CONVERT(date, registration_date) = @registrationDate";
            }
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@searchString", "%" + searchString + "%");
            if (registrationDate.HasValue)
            {
                cmd.Parameters.AddWithValue("@registrationDate", registrationDate.Value.Date);
            }
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student s = new Student();
                    s.id = Convert.ToInt32(dr["id"]);
                    s.StudName = dr["stud_name"].ToString();
                    s.FatherName = dr["father_name"].ToString();
                    s.MotherName = dr["mother_name"].ToString();
                    s.Age = Convert.ToInt32(dr["age"]);
                    s.Address = dr["address"].ToString();
                    s.Registration_Date = Convert.ToDateTime(dr["registration_date"]);
                    list.Add(s);
                }
            }
            con.Close ();
            return list;
        }
        public Student GetStudentById(int id)
        {
            Student s = new Student();
            string qry = "select * from Student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    s.id = Convert.ToInt32(dr["id"]);
                    s.StudName = dr["stud_name"].ToString();
                    s.FatherName = dr["father_name"].ToString();
                    s.MotherName = dr["mother_name"].ToString();
                    s.Age = Convert.ToInt32(dr["age"]);
                    s.Address = dr["address"].ToString();
                    s.Registration_Date = Convert.ToDateTime(dr["registration_date"]);
                }
            }
            con.Close();
            return s;
        }
        public int AddStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "insert into Student values(@stud_name,@father_name,@mother_name,@age,@address,@registration_date,@isActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@stud_name", student.StudName);
            cmd.Parameters.AddWithValue("@father_name", student.FatherName);
            cmd.Parameters.AddWithValue("@mother_name", student.MotherName);
            cmd.Parameters.AddWithValue("@age", student.Age);
            cmd.Parameters.AddWithValue("@address", student.Address);
            cmd.Parameters.AddWithValue("@registration_date", student.Registration_Date);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "update Student set stud_name=@stud_name,father_name=@father_name,mother_name=@mother_name,age=@age,address=@address,registration_date=@registration_date,isActive=@isActive where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@stud_name", student.StudName);
            cmd.Parameters.AddWithValue("@father_name", student.FatherName);
            cmd.Parameters.AddWithValue("@mother_name", student.MotherName);
            cmd.Parameters.AddWithValue("@age", student.Age);
            cmd.Parameters.AddWithValue("@address", student.Address);
            cmd.Parameters.AddWithValue("@registration_date", student.Registration_Date);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            cmd.Parameters.AddWithValue("@id", student.id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "update Student set isActive=0 where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
