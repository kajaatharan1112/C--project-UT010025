using System;
using System.Collections.Generic;
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
                        User_name TEXT NOT NULL PRIMARY KEY ,
                        Password TEXT NOT NULL                       
                    );


                  CREATE TABLE IF NOT EXISTS Corse_table (         
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Status TXT NOT NULl,
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
                        Corse_Id INTEGER NOT NULL,
                        Teacher_Id INTEGER NOT NULL,
                        PRIMARY KEY (Corse_Id, Teacher_Id),
                        FOREIGN KEY (Corse_Id) REFERENCES Corse_table(Id),
                        FOREIGN KEY (Teacher_Id) REFERENCES Teacher_table(Id)
                    );


                    CREATE TABLE IF NOT EXISTS Staf_table (         
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



                 CREATE TABLE IF NOT EXISTS time_table (
                        date TEXT NOT NULL PRIMARY KEY ,
                        Teacher_Id INTEGER NOT NULL,
                        Corse_Id INTEGER NOT NULL,
                        Time_Lap_Id INTEGER NOT NULL,
                        class_Id INTEGER NOT NULL,
                        FOREIGN KEY (Corse_Id) REFERENCES Corse_table(Id),
                        FOREIGN KEY (Teacher_Id) REFERENCES Teacher_table(Id)
                        FOREIGN KEY (class_Id) REFERENCES  Class_table(Id)
                   );



                    CREATE TABLE IF NOT EXISTS Student_table (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Corse_Id INTEGER,
                        Status TEXT NOT NULL,
                        Nic_number INTEGER NOT NULL
                        Address TEXT NOT NULL,

                        FOREIGN KEY (Corse_Id) REFERENCES Corse_table(Id),
                        CHECK (Id > 600000 AND Id < 990000)
                    );

                    CREATE TABLE IF NOT EXISTS Exam_table (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Teacher_Id INTEGER NOT NULL,
                        Corse_Id INTEGER NOT NULL,
                        FOREIGN KEY (Corse_Id) REFERENCES Corse_table(Id),
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
                  

                    ";
                
            }
        }
    }
}
