<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="~/Admin.master" Inherits="_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .lbl {
           
        }

        #header {
            background-color: black;
            color: white;
        }

     
      .td{
            border: 3px solid black;
            width: 400px;
            padding:10px;
           
            
      }
        .highlight {
            background-color: green;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


            <label>Keyword Extraction on the following text:</label>
            <br />
            <asp:Label runat="server" ID="sample1"></asp:Label>
            <br />
            <br />
            <asp:Table runat="server" ID="resultsTable">
                <asp:TableRow>
                    <asp:TableCell CssClass="td">
                        <asp:Label CssClass="lbl" runat="server" ID="lbl_match"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="td">
                        <asp:Label CssClass="lbl" runat="server" ID="lbl_misses"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="td">

                        <asp:Label CssClass="lbl" runat="server" ID="lbl_newWords"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell CssClass="td">

                        <asp:Label CssClass="lbl" runat="server" ID="lbl_expected"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>



</asp:Content>





