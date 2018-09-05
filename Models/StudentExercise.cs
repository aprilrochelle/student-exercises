using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.Sqlite;

namespace nss.Data
{
    public class StudentExercise
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Exercise Exercise { get; set; }
        public Instructor Instructor { get; set; }

        public static void Create(SqliteConnection db)
        {
            db.Execute($@"CREATE TABLE StudentExercise (
                `Id`	        INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                `ExerciseId`	INTEGER NOT NULL,
                `StudentId` 	INTEGER NOT NULL,
                `InstructorId` 	INTEGER NOT NULL,
                FOREIGN KEY(`ExerciseId`) REFERENCES `Exercise`(`Id`),
                FOREIGN KEY(`StudentId`) REFERENCES `Student`(`Id`),
                FOREIGN KEY(`InstructorId`) REFERENCES `Instructor`(`Id`)
            )");
        }
        public static void Seed(SqliteConnection db)
        {

            db.Execute($@"INSERT INTO StudentExercise
                SELECT null, e.Id, s.Id, i.Id
                FROM Student s, Exercise e, Instructor i
                WHERE e.Name = 'Cry in the Shower'
                AND s.SlackHandle = '@April Watson'
                AND i.SlackHandle = '@coach'
            ");


            db.Execute($@"INSERT INTO StudentExercise
                SELECT null, e.Id, s.Id, i.Id
                FROM Student s, Exercise e, Instructor i
                WHERE e.Name = 'Stab Myself'
                AND s.SlackHandle = '@Jenn'
                AND i.SlackHandle = '@coach'
            ");


            db.Execute($@"INSERT INTO StudentExercise
                SELECT null, e.Id, s.Id, i.Id
                FROM Student s, Exercise e, Instructor i
                WHERE e.Name = 'Play in Traffic'
                AND s.SlackHandle = '@Adam Wieckert'
                AND i.SlackHandle = '@joes'
            ");


            db.Execute($@"INSERT INTO StudentExercise
                SELECT null, e.Id, s.Id, i.Id
                FROM Student s, Exercise e, Instructor i
                WHERE e.Name = 'Jump Off Bridge'
                AND s.SlackHandle = '@April Watson'
                AND i.SlackHandle = '@jisie'
            ");
        }
    }

}