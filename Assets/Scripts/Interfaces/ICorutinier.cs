using System.Collections;

public interface ICorutinier
{
    void CorutineStart(IEnumerator enumerator);
    void CorutineStop(IEnumerator enumerator);

}