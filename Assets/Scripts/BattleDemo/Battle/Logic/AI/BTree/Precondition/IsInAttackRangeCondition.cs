﻿using BTreeFrame;

namespace Battle.Logic.AI.BTree
{
    public class IsInAttackRangeCondition : BTreeNodePrecondition<MyInputData>
    {
        public override bool ExternalCondition(MyInputData _input)
        {
            var troop = _input.troop;
            var battleData = _input.battleData;
            if (troop.targetKey != 0)
            {
                TroopData tarTroop = battleData.mAllTroopDic[troop.targetKey];
                if (tarTroop == null)
                {
                    return false;
                }
                uint atkDis = TroopHelper.GetTroopAtkDis(troop.type);
                uint myRange = TroopHelper.GetTroopRange(troop.type);
                uint tarRange = TroopHelper.GetTroopRange(tarTroop.type);
                int dis = MathHelper.TroopDistanceV2(troop, tarTroop);
                if (dis > atkDis + myRange + tarRange)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}