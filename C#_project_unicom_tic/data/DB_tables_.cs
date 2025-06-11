using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__project_unicom_tic.data
{
    internal class DB_tables_
    {
        public static void CreateTables()
        {
            using (var connection = DB_connection.Get_Connection())
            {
                string command = @"
                  CREATE TABLE IF NOT EXISTS Admin_table (         
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Nic_number INTEGER NOT NULL,
                        Address TEXT NOT NULL,
                        CHECK (Id >= 100000 AND Id <= 100050)
                    );

                    CREATE TABLE IF NOT EXISTS User_table (
                        User_id INTEGER NOT NULL,
                        User_name TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Course_table (         
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Status TEXT NOT NULL,
                        Join_date TEXT NOT NULL,
                        Out_date TEXT NOT NULL,
                        CHECK (Id > 100050 AND Id <= 100900)
                    );

                    CREATE TABLE IF NOT EXISTS Teacher_table(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Subject TEXT NOT NULL,
                        Nic_number INTEGER NOT NULL,
                        Status TEXT NOT NULL,
                        Join_date TEXT NOT NULL,
                        Out_date TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        CHECK (Id >= 250000 AND Id < 500000)
                    );

                    CREATE TABLE IF NOT EXISTS Course_Teacher (
                        Course_Id INTEGER NOT NULL,
                        Teacher_Id INTEGER NOT NULL,
                        PRIMARY KEY (Course_Id, Teacher_Id),
                        FOREIGN KEY (Course_Id) REFERENCES Course_table(Id),
                        FOREIGN KEY (Teacher_Id) REFERENCES Teacher_table(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Staff_table (         
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Nic_number INTEGER NOT NULL,
                        Status TEXT NOT NULL,
                        Join_date TEXT NOT NULL,
                        Out_date TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        CHECK (Id >= 105000 AND Id <= 240000)
                    );

                    CREATE TABLE IF NOT EXISTS Class_table (
                        Id INTEGER NOT NULL PRIMARY KEY,
                        Name TEXT NOT NULL                       
                    );

                    CREATE TABLE IF NOT EXISTS Time_table (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT NOT NULL,
                        Teacher_Id INTEGER NOT NULL,
                        Course_Id INTEGER NOT NULL,
                        Time_Lap_Id INTEGER NOT NULL,
                        Class_Id INTEGER NOT NULL,
                        FOREIGN KEY (Course_Id) REFERENCES Course_table(Id),
                        FOREIGN KEY (Teacher_Id) REFERENCES Teacher_table(Id),
                        FOREIGN KEY (Class_Id) REFERENCES Class_table(Id),
                        CHECK (Id > 10000000 AND Id < 99999999)
                    );

                    CREATE TABLE IF NOT EXISTS Student_table (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Course_Id INTEGER,
                        Status TEXT NOT NULL,
                        Nic_number INTEGER NOT NULL,
                        Address TEXT NOT NULL,
                        FOREIGN KEY (Course_Id) REFERENCES Course_table(Id),
                        CHECK (Id > 600000 AND Id < 990000)
                    );

                    CREATE TABLE IF NOT EXISTS Exam_table (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Teacher_Id INTEGER NOT NULL,
                        Course_Id INTEGER NOT NULL,
                        FOREIGN KEY (Course_Id) REFERENCES Course_table(Id),
                        FOREIGN KEY (Teacher_Id) REFERENCES Teacher_table(Id),
                        CHECK (Id > 1000 AND Id < 9999)
                    );

                    CREATE TABLE IF NOT EXISTS Marks_table (
                        Student_Id INTEGER NOT NULL,
                        Exam_Id INTEGER NOT NULL,
                        Exam_marks INTEGER NOT NULL, 
                        PRIMARY KEY (Student_Id, Exam_Id),
                        FOREIGN KEY (Student_Id) REFERENCES Student_table(Id),
                        FOREIGN KEY (Exam_Id) REFERENCES Exam_table(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Teacher_Attendance (
                        Date TEXT NOT NULL,
                        Teacher_Id INTEGER NOT NULL,
                        Status TEXT NOT NULL,
                        PRIMARY KEY (Date, Teacher_Id),
                        FOREIGN KEY (Teacher_Id) REFERENCES Teacher_table(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Student_Attendance (
                        Date TEXT NOT NULL,
                        Student_Id INTEGER NOT NULL,
                        Class_Id INTEGER NOT NULL,
                        Status TEXT NOT NULL,
                        PRIMARY KEY (Date, Student_Id),
                        FOREIGN KEY (Class_Id) REFERENCES Time_table(Id),
                        FOREIGN KEY (Student_Id) REFERENCES Student_table(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Staff_Attendance (
                        Date TEXT NOT NULL,
                        Staff_Id INTEGER NOT NULL,
                        Status TEXT NOT NULL,
                        PRIMARY KEY (Date, Staff_Id),
                        FOREIGN KEY (Staff_Id) REFERENCES Staff_table(Id)
                    );


                    ";
                SQLiteCommand cmd=new SQLiteCommand(command, connection);
                cmd.ExecuteNonQuery();
                
            }
        }
    }
}
