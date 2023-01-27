using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sephirah.Models
{
    public class EgoWeapon
    {
        public int AbnoID { get; set; }
        public string EgoWeaponName { get; set; }
        public string EgoWeaponAbnoName { get; set; }
        public string EgoWeaponRiskLevel { get; set; }
        public string EgoWeaponImagePath { get; set; }

        public string DamageType { get; set; }
        public string DamageRange { get; set; }
        public string AttackSpeed { get; set; }
        public string AttackRange { get; set; }

        public string EgoWeaponDescription { get; set; }
        public string EgoWeaponAbility { get; set; }

        public EgoWeapon()
        {

        }

        public EgoWeapon(int abnoID, string egoWeaponName, string egoWeaponAbnoName, string egoWeaponRiskLevel, string egoWeaponImagePath, 
            string damageType, string damageRange, string attackSpeed, string attackRange, string egoWeaponDescription, string egoWeaponAbility)
        {
            AbnoID = abnoID;
            EgoWeaponName = egoWeaponName;
            EgoWeaponAbnoName = egoWeaponAbnoName;
            EgoWeaponRiskLevel = egoWeaponRiskLevel;
            EgoWeaponImagePath = egoWeaponImagePath;
            DamageType = damageType;
            DamageRange = damageRange;
            AttackSpeed = attackSpeed;
            AttackRange = attackRange;
            EgoWeaponDescription = egoWeaponDescription;
            EgoWeaponAbility = egoWeaponAbility;
        }
    }
}
