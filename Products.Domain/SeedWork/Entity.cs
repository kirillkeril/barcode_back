namespace Products.Domain.SeedWork;

public abstract class Entity
{
    private Guid _id;
    public virtual Guid Id
    {
        get => _id;
        protected set => _id = value;
    }

    public Entity()
    {
        _id = Guid.NewGuid();
    }

    public Entity(Guid id)
    {
        _id = id;
    }
    
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Entity)obj);
    }

    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }
    
    public static bool operator ==(Entity? left, Entity? right)
    {
        return Equals(left, null) ? Equals(right, null) : left.Equals(right);
    }
    
    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }
}