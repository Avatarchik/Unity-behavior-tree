﻿using Battle.Logic;
public class BattleView
{

    private BattleData m_BattleData;
    private BattleLogicCtrl m_BattleLogic;
    


    public void Dispose()
    {
        Exit();
    }

    public void Init(BattleData _battleData)
    {
        m_BattleData = _battleData;
        m_BattleLogic = new BattleLogicCtrl(m_BattleData, m_BattleData.mSeed);
        //NeatlyTimer.AddFrame(this, OnUpdate);
    }

    public void SyncFrame(BattleData data)
    {
        Debugger.Log("完成帧：" + data.mFinishFrame);
        m_BattleLogic.SetFinishFrame(data.mFinishFrame);
        AddCommand(data.mOperators);
        int currentFrame = data.mCurrentFrame;
        while (true)
        {
            if (m_BattleLogic.m_currentFrame >= currentFrame - 1)
            {
                return;
            }
            LogicState state = m_BattleLogic.Update();
            if (state == LogicState.End)
            {
                Exit();
                return;
            }
        }
    }

    private void OnUpdate(float dt)
    {
        LogicState result = m_BattleLogic.Update(dt);
        if (result == LogicState.Playing)
        {

        }
        else if (result == LogicState.End)
        {
            Exit();
        }
    }
    
    //添加指令
    private void AddCommand(string operators)
    {

    }

    //退出战场
    private void Exit()
    {
        //NeatlyTimer.Remove(this);
        if (BattleLogicDefine.isServer)
        {

        }
    }
}