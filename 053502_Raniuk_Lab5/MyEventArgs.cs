using System;

public class MyEventArgs : EventArgs, IEquatable<MyEventArgs>
   // where T : IEquatable<T>

{
    public string Name {get;set;} 
    public bool Equals(MyEventArgs other)
    {
        if (other == null)
            return false;

        return this.Name == other.Name;
    }
}