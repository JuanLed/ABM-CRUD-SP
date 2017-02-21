<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="CapaUI.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            width: 991px;
            margin-left: 0px;
            height: 501px;
        }
    </style>
</head>
<body style="width: 985px; margin-left: 20px; font-family: 'Courier New', Courier, monospace; font: caption; background-color: #e6e6e6;">
    <form id="form1" runat="server">
    <div>
    
      
        </div>
        &nbsp;
        <asp:Button ID="insertbtn" runat="server" Text="Insert / Modify" OnClick="insertbtn_Click" Width="124px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="deletebtn" runat="server" Text="Delete by ID" OnClick="deletebtn_Click" Width="92px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="bringBtn" runat="server" CausesValidation="False" Text="Show by ID" Width="77px" OnClick="bringBtn_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="showBtn" runat="server" Text="Update @" Width="134px" OnClick="showBtn_Click" BackColor="#9999FF" BorderColor="Black" style="margin-left: 0px" />
        <br />
        <br />
        <asp:TextBox ID="primerNombre" runat="server" OnTextChanged="TextBox1_TextChanged" Height="22px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label runat="server" BorderColor="#9999FF" BorderStyle="Solid" Font-Bold="True" Text="Primer Nombre" Width="93px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="intID" runat="server" Width="28px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Label runat="server" BorderColor="#9999FF" BorderStyle="Solid" EnableTheming="True" Font-Bold="True" Text="ID Number" Width="63px"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="segundoNombre" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label runat="server" BorderColor="#9999FF" BorderStyle="Solid" Font-Bold="True" Text="Segundo Nombre" Width="105px"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="sueldo" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label runat="server" BorderColor="#9999FF" BorderStyle="Solid" Font-Bold="True" Text="Sueldo" Width="41px"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="antiguedad" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label runat="server" BorderColor="#9999FF" BorderStyle="Solid" Font-Bold="True" Text="Antiguedad" Width="69px"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="puesto" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label runat="server" BorderColor="#9999FF" BorderStyle="Solid" Font-Bold="True" Text="Puesto"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridViewEmp" runat="server" Height="264px" OnSelectedIndexChanged="GridViewEmp_SelectedIndexChanged" Width="537px">
        </asp:GridView>
        <asp:Label ID="errorLabel" runat="server" BorderColor="#99CCFF" BorderStyle="Groove" Text="Shows Error" Width="528px"></asp:Label>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
