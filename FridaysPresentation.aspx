﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FridaysPresentation.aspx.cs" Inherits="FridaysPresentation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Presentation</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


    <style>
        body {
            text-align: right;
            color: black;
        }
<<<<<<< HEAD
        h2{
            font-weight:700;
        }
        h3{
            text-decoration:underline;
        }
=======

        h2 {
            font-weight: 700;
        }

        h3 {
            text-decoration: underline;
        }

>>>>>>> d50389ba26abb55ff48e05afe4a56f9ba265888c
        p {
            font-size: 1.6em
        }

        #header {

            text-align: center;
            margin-bottom: 50px;

        }

        #div_goals {
        }

        #div_mainModules {
        }

        #div_forMarch {
        }

        .jumbotron:hover {
            background-color: rgba(120,206,244,0.3)
        }

        .container {
            margin-top: 10px;
        }
        #header img{
            height:150px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
            <div id="header">
               <img src="images/mapmeImge.png" />
            </div>
            <div id="div_goals" class="jumbotron">
                <h2>מטרות הפרוייקט</h2>
                <p>
                    מטרת מערכת ענני מחקר היא לסייע לחוקרים בתחומים שונים ממקומות שונים למצוא שיתופי פעולה
                    .עם חוקרים אחרים אשר עוסקים באותו תחום ועדכון כל המידע בצורה אוטומטית בהתבסס על המחקרים שנמצאים במערכת
                </p>
            </div>

            <div id="div_mainModules" class="jumbotron">
                <h2>מודולים מרכזיים </h2>
                <h3>הוצאת מילות\משפטי מפתח </h3>
                <p>
                    .חילוץ מילים\משפטים רלוונטים בצורה אוטומטית מהמאמרים שמסופקים ע"י המשתמשים במערכת
                    <br />
                    כרגע, מתבסס בעיקר על אלגוריתם בשם
                    <br />
                    <a href="https://goo.gl/YQfLF2">RAKE (Rapid Automatic Keyword Extraction)</a>
                    <br />
                    .שנמצא בנתיים הכי מדוייק מכל האלגוריתמים שנבדקו למשיכת מידע מקבצי טקסט ללא התבססות על קורפוס
                    <br />

                </p>
                <h3>הגדרת החוקר ויצירת קבוצות מחקר\קלסתרים</h3>
                <p>
                    .בהתבסס על המחרוזות שמתקבלות מהמאמרים, יוגדרו מספר תגיות לכל משתמש באופן אטומטי
                    <br />
                    לאחר הגדרת החוקרים, יוגדרו  קבוצות מחקר המאגדות חוקרים בהתבסס על תחום המחקר והתגיות
                </p>
                <h3>אנימציית מיפוי החוקר</h3>
                <p>
                    מודול זה יורכב מאנימציה אינטרקטיבית שמטרתה להציג בצורה ויזאולית ונעימה 
                    <br />
                    היכן ממופה החוקר (במוסד האקדמי עצמו ובמוסדות אחרים) מבחינת הנושאים שהוא מתעסק בהם
                    <br />
                    .ביחס לחוקרים אחרים, ובדרך זו גם תנגיש בצורה ידידותית שיתופי פעולה רלוונטיים
                </p>
                <h3>ממשק אדמין \מנהל המחקר של המוסד</h3>
                <p>
                    מודול זה ינגיש בצורה ויזואלית באמצעות גרפים שונים נתונים על החוקרים במוסד מסויים
                    <br />
                    למנהל המחקר של המוסד תהיה אפשרות לראות נתונים ושינויים לאורך זמן על
                    <br />
                    הנושאים שנחקרים במוסד ועל שיתופי פעולה ספציפיים לפי חיפושים שונים אשר
                    <br />
                    .בדרך אחרת לא היו נגישים לשאר החוקרים במוסד
                    <br />
                    ייתכן שתתווסף למודול זה האפשרות להציג את כל הפרסומים של חוקרים במוסד שפרסמו 
                    <br />
                    תחת שם המוסד הזה
                </p>
            </div>
            <div id="div_forMarch" class="jumbotron">
                <h2>הגשה מתוכננת לסוף מרץ</h2>
                <h3>הוכחת יכולת על מסד נתונים פיקטיבי</h3>
                <p>
                    הצגה של מודול אנימציית מיפוי החוקר ומודול ממשק הניהול על 
                    <br />
                    בסיס נתונים לבדיקה שאנחנו הזנו בעצמנו
                </p>
                <h3>מודול חילוץ מילות מפתח</h3>
                <p>
                    הוכחת יכולת למציאת מספר מצומצם יחסית של מילות מפתח באמצעות מודול חילוץ מילות המפתח
                </p>
            </div>


            <div id="div_resources" class="jumbotron">
                <h2>מה עשינו בנתיים</h2>
                <h3>התחלת בניית מסכים</h3>
                <p>
                    mobile-first
                    המסכים כרגע מותאמים רק למובייל, אנו מעוניינים להציג
                    <br />
                    את הזרימה בניהם ואת התוכן בדף וניגש לעיצוב בשלב מאוחר יותר
                    <br />
                    <a href="http://proj.ruppin.ac.il/bgroup62/test1/tar1/htmlMockup/index.html">קישור למסכים שבנינו בנתיים
                    </a>
                </p>
                <h3>RAKE שימוש בסיסי באלגוריתם </h3>
                <p>
                    .מצאנו כמה ספריות סי שארפ שמימשו את האלגוריתם
                    <br />
                    בנתיים נעשה שימוש בספרייה של
                    <br />
                    <a href="https://github.com/benmcevoy/Rake">Benmcevoy</a>
                    <br />
                    קיימים כרגע 3 דפים
                    <br />
                    הצגת מילים מהמאמרים של עמית, עם אפשרות לשנות פרמטרים
                    <a href="AmitRakeTest.aspx">קישור</a>
                    <br />
                    הצגת מילות חיפוש מטקסט שמוזן ע"י המשתמש
                     <a href="TryRake.aspx">קישור</a>
                    <br />
                    הצגת והשוואת תוצאות ששמורות במסד הנתונים של 62 תוצאות
                    <br />
                    על אותו מאמר עם פרמטרים שונים
                    <a href="ShowDatabaseTestResults.aspx">קישור</a>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
