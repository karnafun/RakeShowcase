<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TryRake.aspx.cs" MasterPageFile="~/Admin.master" Inherits="TryRake" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        #header {
            background-color: black;
            color: white;
        }

        .td {
             margin: 0;
            vertical-align: top;
            padding: 10px;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell CssClass="td">
                <h3>Enter Text:</h3>
                <asp:TextBox runat="server" ID="textTB" Columns="70" Rows="20" TextMode="MultiLine">
                </asp:TextBox>
            </asp:TableCell>

            <asp:TableCell CssClass="td">
                <h3>Results:</h3>
                <asp:Label runat="server" ID="lbl_results"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button runat="server" ID="submitBTN" OnClick="submitBTN_Click" Text="Go" />

</asp:Content>

