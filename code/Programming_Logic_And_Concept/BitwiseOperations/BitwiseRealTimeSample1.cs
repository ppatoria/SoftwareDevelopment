public class States
{
    private const int MASK_DID_HOMEWORK  = 0x0001;
    private const int MASK_ATE_DINNER    = 0x0002;
    private const int MASK_SLEPT_WELL    = 0x0004; 

    public int m_nCurState;// This is my current state

    public static void Main()
        {
            States st = new States();
            // Set state for'ate dinner' and 'slept well' to 'on'
            st.m_nCurState = st.m_nCurState | (MASK_ATE_DINNER | MASK_SLEPT_WELL);

            // Turn off the 'ate dinner' flag
            st.m_nCurState = (st.m_nCurState & ~MASK_ATE_DINNER);
            st.CheckCurrentState();
        }

    void CheckCurrentState()
        {
            if (m_nCurState & MASK_DID_HOMEWORK)
                Console.WriteLIne("MASK_DID_HOMEWORK");
            else if (m_nCurState & MASK_ATE_DINNER)
                Console.WriteLIne("MASK_ATE_DINNER");
            else if (m_nCurState & MASK_SLEPT_WELL)
                Console.WriteLIne("MASK_SLEPT_WELL");
        }
}