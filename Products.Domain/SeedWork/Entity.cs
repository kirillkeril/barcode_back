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

    private bool Equals(Entity other)
    {
        return _id.Equals(other._id);
    }

    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }
    
    public static bool operator ==(Entity? left, Entity? right)
    {
        if (Equals(left, null))
            return (Equals(right, null));
        return left.Equals(right);
    }
    
    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }
}