<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowDatabaseTestResults.aspx.cs" Inherits="ShowDatabaseTestResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table td{
            border:2px solid black;
            text-align:center;
            font-size:1.8em;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:DropDownList ID="ddl_maxWords" runat="server" AutoPostBack="true"></asp:DropDownList>
        <div id="div_res" runat="server"></div>
        <%--<asp:Table runat="server" ID="tbl_res">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Test Id</asp:TableHeaderCell>
                <asp:TableHeaderCell>Minimum Char Length</asp:TableHeaderCell>
                <asp:TableHeaderCell>Maximum Words Length</asp:TableHeaderCell>
                <asp:TableHeaderCell>Minimum Word Frequency</asp:TableHeaderCell>
                   <asp:TableHeaderCell>Keyword</asp:TableHeaderCell>
                   <asp:TableHeaderCell>Score</asp:TableHeaderCell>
            </asp:TableHeaderRow>

        </asp:Table>--%>
    </div>
    </form>
</body>
</html>
