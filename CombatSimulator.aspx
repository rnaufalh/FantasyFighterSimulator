<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CombatSimulator.aspx.cs" Inherits="FantasyFighterSimulator.CombatSimulator" %>

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
            <a class="nav-link active" href="CombatSimulator.aspx">Simulator</a>
        </div>        
    </nav>

    <form id="form1" runat="server">
        <div>
            <h1 class="text-center my-2">Combat Simulator</h1>
            <hr />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [CharacterId], [Name] FROM [Characters]"></asp:SqlDataSource>
            <div class="container text-center">
                <div class="row">
                    <div class="col">
                        <label>Select Player:</label> 
                        <br />
                        <asp:DropDownList ID="PlayerSelect" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="CharacterId">
                        </asp:DropDownList>
                    </div>
                    <div class="col">
                        <label>Select Opponent:</label>
                        <br />
                        <asp:DropDownList ID="OpponentSelect" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="CharacterId">
                        </asp:DropDownList>
                    </div>
                </div>                
            </div>
            <br />
            <br />

            <div class="text-center">
                <asp:Button ID="ConfirmFighters" CssClass="btn btn-primary btn-lrg" runat="server" OnClick="ConfirmFighters_Click" Text="Confirm Fighter Select" />
            </div>
            <br />
            <br />

            <div class="text-center">
                <asp:Button ID="PlayerAttackButton" CssClass="btn btn-danger btn-lrg mx-3" runat="server" Enabled="False" OnClick="PlayerAttackButton_Click" Text="Hit Opponent" />
                <asp:Button ID="PlayerSpecialButton" CssClass="btn btn-warning btn-lrg mx-3" runat="server" Enabled="False" OnClick="PlayerSpecialButton_Click" Text="Use Special Skill" />
                <asp:Button ID="PlayerDefensiveButton" CssClass="btn btn-success btn-lrg mx-3" runat="server" Enabled="False" OnClick="PlayerDefensiveButton_Click" Text="Use Defensive Skill" />

                <asp:Button ID="ShowInfo" CssClass="btn btn-info btn-lrg mx-3" runat="server" Enabled="False" Text="Show Fighters Info" OnClick="ShowInfo_Click" />
                <br />
                <asp:TextBox ID="CombatRundown" CssClass="my-3" runat="server" style="width:500px;height:300px;overflow:auto;" TextMode="MultiLine" ReadOnly="True">Please select two fighters</asp:TextBox>
            </div>           
            <br />
            <br />
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
