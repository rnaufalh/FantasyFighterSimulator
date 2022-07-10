using ObjectClasses;
using ObjectClasses.Armors;
using ObjectClasses.Characters.MagicCharacters;
using ObjectClasses.Characters.NormalCharacters;
using ObjectClasses.Weapons;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FantasyFighterSimulator
{
    public partial class CombatSimulator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ConfirmFighters_Click(object sender, EventArgs e)
        {
            int playerId = Int32.Parse(PlayerSelect.SelectedValue);
            int opponentId = Int32.Parse(OpponentSelect.SelectedValue);

            // Initialize characters
            Character playerChar = new Mage();
            Character opponentChar = new Mage();

            // Initiale connection with database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();

            // To query the selected characters
            string fightersQuery =
                "SELECT c.CharacterId, c.Name, c.JobType, c.HP, c.AP, c.Speed, w.Name, w.WeaponType, w.DamageDealt, a.Name, a.ArmorType, a.ArmorPoints " +
                "FROM [Characters] AS c " +
                "INNER JOIN [Weapons] AS w ON c.WeaponId=w.WeaponId " +
                "INNER JOIN [Armors] AS a ON c.ArmorId=a.ArmorId " +
                "WHERE c.CharacterId=" + playerId + " OR c.CharacterId=" + opponentId + ";";

            SqlCommand cmd = new SqlCommand(fightersQuery, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            // Read each row to initiate the object characters
            while(reader.Read())
            {
                // To obtain character details to be used for the initiator method
                List<string> characterData = new List<string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    characterData.Add(reader[i].ToString());
                }

                if (reader[0].Equals(playerId))
                {
                    playerChar = InitializeFighter(characterData);
                }
                else
                {
                    opponentChar = InitializeFighter(characterData);
                }
            }

            CombatRundown.Text = "Begin Combat! " + playerChar.Name + " vs " + opponentChar.Name + "\n";

            // Store the character objects into session to be used (can't use varaibles since the page will reload everytime this method is called)
            Session["PlayerChar"] = playerChar;
            Session["OpponentChar"] = opponentChar;
            Session["TurnCounter"] = 1;

            ConfirmFighters.Enabled = false;

            // To compare the characters' speed to see which one to move
            if (playerChar.Speed >= opponentChar.Speed)
            {
                CombatRundown.Text += "-- ROUND " + Session["TurnCounter"] + " --\n";
                Session["TurnCounter"] = (int)Session["TurnCounter"] + 1;
                
                PlayerAttackButton.Enabled = true;
                PlayerSpecialButton.Enabled = true;
                PlayerDefensiveButton.Enabled = true;
                ShowInfo.Enabled = true;
            }
            else
            {
                OpponentMove();
            }
        }

        public Character InitializeFighter(List<string> charData)
        {
            Character character;
            
            // Initialize depending on the Job Type
            if (charData[2].Equals("Warrior"))
            {
                character = new Warrior();
            }
            else
            {
                character = new Mage();
            }

            character.Name = charData[1];
            character.HealthPoints = Int32.Parse(charData[3]);
            character.AbilityPoints = Int32.Parse(charData[4]);
            character.Speed = Int32.Parse(charData[5]);

            // Initialize Weapon depending on the Weapon Type
            Weapon charWeapon;
            if (charData[7].Equals("Axe"))
            {
                charWeapon = new Axe(charData[6], Int32.Parse(charData[8]));   
            }
            else
            {
                charWeapon = new Staff(charData[6], Int32.Parse(charData[8]));
            }

            character.CharWeapon = charWeapon;

            // Initialize Armor depending on the Armor Type
            Armor charArmor;
            if (charData[10].Equals("Medium Armor"))
            {
                charArmor = new MediumArmor(charData[9], Int32.Parse(charData[11]));        
            }
            else
            {
                charArmor = new Robe(charData[9], Int32.Parse(charData[11]));
            }

            character.BodyArmor = charArmor;

            return character;
        }

        protected void ShowInfo_Click(object sender, EventArgs e)
        {
            Character playerChar = (Character)Session["PlayerChar"];
            Character opponentChar = (Character)Session["OpponentChar"];

            CombatRundown.Text += "[Player " + playerChar.Name + " HP: " + playerChar.HealthPoints + ", AP: " + playerChar.AbilityPoints
                + " | Opponent " + opponentChar.Name + " HP: " + opponentChar.HealthPoints + ", AP: " + opponentChar.AbilityPoints + "]\n";
        }

        // When the player choose to do Normal Attack to the opponent
        protected void PlayerAttackButton_Click(object sender, EventArgs e)
        {
            Character playerChar = (Character) Session["PlayerChar"];
            Character opponentChar = (Character)Session["OpponentChar"];

            CombatRundown.Text += playerChar.NormalAttack(opponentChar);

            // To check if the opponent's health is depleted
            if (opponentChar.HealthPoints == 0)
            {
                CombatComplete("Player " + playerChar.Name);
            }
            else
            {
                OpponentMove();
            }
        }

        // When the player choose to use Special Skill to the opponent
        protected void PlayerSpecialButton_Click(object sender, EventArgs e)
        {
            Character playerChar = (Character)Session["PlayerChar"];
            Character opponentChar = (Character)Session["OpponentChar"];

            CombatRundown.Text += playerChar.SpecialSkill(opponentChar);

            // To check if the skill was used when the SP/MP is still available
            if (playerChar.HasMoved)
            {
                // To check if the opponent's health is depleted
                if (opponentChar.HealthPoints == 0)
                {
                    CombatComplete("Player " + playerChar.Name);
                }
                else
                {
                    OpponentMove();
                }
            }
        }

        // When the player choose to use Defensive Skill
        protected void PlayerDefensiveButton_Click(object sender, EventArgs e)
        {
            Character playerChar = (Character)Session["PlayerChar"];
            Character opponentChar = (Character)Session["OpponentChar"];

            CombatRundown.Text += playerChar.DefensiveSkill();

            // To check if the skill was used when the SP/MP is still available
            if (playerChar.HasMoved)
            {
                OpponentMove();
            }
        }

        // To determine the opponent's move (in a random way)
        public void OpponentMove()
        {
            PlayerAttackButton.Enabled = false;
            PlayerSpecialButton.Enabled = false;
            PlayerDefensiveButton.Enabled = false;
            ShowInfo.Enabled = false;

            Character playerChar = (Character)Session["PlayerChar"];
            Character opponentChar = (Character)Session["OpponentChar"];

            // To show a round has begun (if OPPONENT is the one that starts the combat)
            if (!playerChar.HasMoved || (playerChar.HasMoved && opponentChar.HasMoved))
            {
                CombatRundown.Text += "-- ROUND " + Session["TurnCounter"] + " --\n";
                Session["TurnCounter"] = (int) Session["TurnCounter"] + 1;

                playerChar.HasMoved = false;
                opponentChar.HasMoved = false;
            }

            Random rng = new Random();
            while (!opponentChar.HasMoved)
            {
                int moveSelector = rng.Next(1, 4);
                if (moveSelector == 1)  // Do Normal Attack to player
                {
                    CombatRundown.Text += opponentChar.NormalAttack(playerChar);
                }
                else if (moveSelector == 2 && opponentChar.AbilityPoints != 0)  // Use Special Skill to player
                {
                    CombatRundown.Text += opponentChar.SpecialSkill(playerChar);
                }
                else if (moveSelector == 3 && opponentChar.AbilityPoints != 0)  // Use Defensive Skill to opponent
                {
                    CombatRundown.Text += opponentChar.DefensiveSkill();

                }
            }

            // To check if the player's health is depleted
            if (playerChar.HealthPoints == 0)
            {
                CombatComplete("Opponent " + opponentChar.Name);
            }
            else
            {
                // To show a round has begun (if PLAYER is the one that starts the combat)
                if (playerChar.HasMoved && opponentChar.HasMoved)
                {
                    CombatRundown.Text += "-- ROUND " + Session["TurnCounter"] + " --\n";
                    Session["TurnCounter"] = (int)Session["TurnCounter"] + 1;

                    playerChar.HasMoved = false;
                    opponentChar.HasMoved = false;
                }
                
                PlayerAttackButton.Enabled = true;
                PlayerSpecialButton.Enabled = true;
                PlayerDefensiveButton.Enabled = true;
                ShowInfo.Enabled = true;
            }
        }

        // A method called when one of the fighter's health is depleted
        public void CombatComplete(string winner)
        {
            PlayerAttackButton.Enabled = false;
            PlayerSpecialButton.Enabled = false;
            PlayerDefensiveButton.Enabled = false;
            ConfirmFighters.Enabled = true;

            CombatRundown.Text += "-- Combat Complete, " + winner + " is Victorious! --\n";
        }        
    }
}