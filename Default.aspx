<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rake Example</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        .lbl {
           
        }

        #header {
            background-color: black;
            color: white;
        }

        #resultsTable td {
            border: 3px solid black;
            width: 400px;
            padding:10px;
            
        }
      
        .highlight {
            background-color: green;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header" >
            <h3 >RAKE Showcase   <a href="#" style="font-size:15px;">Try It Yourself</a></h3>
            
        </div>
        <br />
        <div class="container">


            <label>Keyword Extraction on the following text:</label>
            <br />
            <asp:Label runat="server" ID="sample1"></asp:Label>
            <br />
            <br />
            <asp:Table runat="server" ID="resultsTable">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label CssClass="lbl" runat="server" ID="lbl_match"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label CssClass="lbl" runat="server" ID="lbl_misses"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>

                        <asp:Label CssClass="lbl" runat="server" ID="lbl_newWords"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>

                        <asp:Label CssClass="lbl" runat="server" ID="lbl_expected"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>






        </div>
    </form>
</body>
</html>
