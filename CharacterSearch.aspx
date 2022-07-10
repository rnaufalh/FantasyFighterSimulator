<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CharacterSearch.aspx.cs" Inherits="FantasyFighterSimulator.CharacterSearch" %>

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
            <a class="nav-link active" href="CharacterSearch.aspx">Characters</a>
            <a class="nav-link" href="CombatSimulator.aspx">Simulator</a>
        </div>        
    </nav>

    <form class="container-fluid" id="form1" runat="server">
        <h1 class="text-center my-2">List of Characters</h1>
        <hr />
        <div class="row">
            <div class="form-group col-3 bg-light">
                <label class="font-weight-bold">Job Type:</label>
                <br />
                <asp:RadioButtonList CssClass="form-check" ID="JobTypeList" runat="server">
                    <asp:ListItem>Warrior</asp:ListItem>
                    <asp:ListItem>Mage</asp:ListItem>
                </asp:RadioButtonList>
                <label class="font-weight-bold">Name:</label>
                <br />
                <asp:TextBox CssClass="form-control" ID="SearchTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Button CssClass="btn btn-primary" ID="ApplyFilters" runat="server" Text="Apply Filters" OnClick="ApplyFilters_Click" />
                <br />
                <br />
            </div>

            <div class="col">
                <asp:GridView ID="CharGridView" CssClass="table table-secondary bg-light table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="CharacterId" OnSelectedIndexChanged="CharGridView_SelectedIndexChanged" ShowHeaderWhenEmpty="True">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="CharacterId" HeaderText="CharacterId" SortExpression="CharacterId" Visible="false"/>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="JobType" HeaderText="JobType" SortExpression="JobType" />
                        <asp:BoundField DataField="HP" HeaderText="HP" SortExpression="HP" />
                        <asp:BoundField DataField="AP" HeaderText="AP" SortExpression="AP" />
                        <asp:BoundField DataField="Speed" HeaderText="Speed" SortExpression="Speed" />
                    </Columns>
                </asp:GridView>    
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
