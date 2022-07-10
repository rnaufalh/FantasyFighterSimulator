<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CharacterDetails.aspx.cs" Inherits="FantasyFighterSimulator.CharacterDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <nav class="navbar navbar-expand navbar-dark bg-primary">
        <span class="navbar-brand font-weight-bold">FanFightSim</span>
        
        <div class="navbar-nav" >
            <a class="nav-link" href="Default.aspx">Home</a>
            <a class="nav-link" href="CharacterSearch.aspx">Characters</a>
            <a class="nav-link" href="CombatSimulator.aspx">Simulator</a>
        </div>        
    </nav>

    <form id="form1" runat="server">
        <div class="container">
            <h1 class="text-center my-2">Character Details Page</h1>
            <hr />

            <asp:Table ID="CharacterDataTable" CssClass="table table-borderless" runat="server">
                <asp:TableHeaderRow CssClass="thead-dark text-center">
                    <asp:TableHeaderCell  ColumnSpan="2">Character Data</asp:TableHeaderCell>         
                </asp:TableHeaderRow>
                <asp:TableRow CssClass="table-secondary">
                    <asp:TableCell CssClass="font-weight-bold">Name</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="font-weight-bold">Job Type</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="table-secondary">
                    <asp:TableCell CssClass="font-weight-bold">HP</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="font-weight-bold">SP/MP</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="table-secondary">
                    <asp:TableCell CssClass="font-weight-bold">Speed</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />

            <asp:Table ID="WeaponDataTable" CssClass="table table-borderless" runat="server">
                <asp:TableHeaderRow CssClass="thead-dark text-center">
                    <asp:TableHeaderCell ColumnSpan="2">Weapon Data</asp:TableHeaderCell>         
                </asp:TableHeaderRow>
                <asp:TableRow CssClass="table-secondary">
                    <asp:TableCell CssClass="font-weight-bold">Weapon Name</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="font-weight-bold">Weapon Type</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="table-secondary">
                    <asp:TableCell CssClass="font-weight-bold">Weapon Damage</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />

            <asp:Table ID="ArmorDataTable" CssClass="table table-borderless" runat="server">
                <asp:TableHeaderRow CssClass="thead-dark text-center">
                    <asp:TableHeaderCell ColumnSpan="2">Armor Data</asp:TableHeaderCell>         
                </asp:TableHeaderRow>
                <asp:TableRow CssClass="table-secondary">
                    <asp:TableCell CssClass="font-weight-bold">Armor Name</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="font-weight-bold">Armor Type</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="table-secondary">
                    <asp:TableCell CssClass="font-weight-bold">Armor Defense</asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
