<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FantasyFighterSimulator.WebForm1" %>

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
            <a class="nav-link active" href="Default.aspx">Home</a>
            <a class="nav-link" href="CharacterSearch.aspx">Characters</a>
            <a class="nav-link" href="CombatSimulator.aspx">Simulator</a>
        </div>        
    </nav>


    <form id="form1" runat="server">
        <div class="container text-center">
            <div class="jumbotron">
                <h1>FANTASY FIGHTER SIMULATOR</h1>
                <hr />
                <p>
                    <strong>Pick a Fighter!</strong> 
                    Face your opponent in a text-based battle! 
                </p>
                <br />
                <asp:Button ID="FightSim" class="btn btn-primary btn-lrg" runat="server" Text="Fight Simulator" OnClick="FightSim_Click" />
                <br />
                <br />
                <asp:Button ID="SearchChar" class="btn btn-outline-primary btn-lrg" runat="server" Text="Search Character Details" OnClick="SearchChar_Click" />          
            </div>
            
        </div>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
