<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TryRake.aspx.cs" Inherits="TryRake" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Try Rake</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
         #header {
            background-color: black;
            color: white;
        }

         table td{
             margin:0;
             vertical-align:top;
             padding:10px;
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
        

       

        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <h3>Enter Text:</h3>
     <asp:TextBox runat="server" ID="textTB" Columns="70" Rows="20" TextMode="MultiLine">
     </asp:TextBox>
                </asp:TableCell>
                
                <asp:TableCell>
                    <h3>Results:</h3>
                    <asp:Label runat="server" ID="lbl_results"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
        <asp:Button runat="server" ID="submitBTN" OnClick="submitBTN_Click"  Text="Go"/>
    </div>
    </form>
</body>
</html>
