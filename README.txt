Mathias Hjelmqvist
A simple 2D platform game with collectible coins, unlockable "doors", turret enemy etc.

Patterns:

- Singleton, in `Wallet.cs` in `class Wallet` as `Wallet.Instance`
  Used singleton to make a single instance of the Wallet class that can be accesssed from anywhere

- Components, in `PlayerCharacter.cs` in `class PlayerCharacter` as `PlayerInput` and `PlayerMovement`
  Creates instances of PlayerInput and PlayerMovement in Awake and calls their OnUpdate methods in Update.

- Dependency injection, in... 
      `PlayerCharacter.cs` in `class PlayerCharacter` as `PlayerInput & PlayerMovement`
       PlayerInput receives input names.
       PlayerMovement receives a PlayerInput and a Character.

      `Turret.cs` in `class Turret` as `ComponentPool<Projectile>` and `ChangeState`
       ComponentPool constructor requires a prefab which is set in the inspector of Turret.
       TurretSearchState requires a Turret.
       TurretAttackState requires a Turret and a PlayerCharacter.

- Observer, in...
      `Health.cs` in `class Health` as `OnHealthChanged`
       Called when health has been changed, used to update UI stop PlayerCharacter from moving on death etc.

      `PlayerCharacter.cs` in `class PlayerCharacter` as `OnPlayerDeath`
       Called when health reaches 0 or below, opens lose UI and disables collider.

      `Wallet.cs` in `class Wallet` as `OnGoldChanged`
       Called when adding or removing gold, used to update UI

      `Door.cs` in `class Door` as `OnReachedDoor`
       Called when PlayerCharacter reaches the door, used to open finish UI

      `Key.cs` in `class Key` as `OnKeyPickedUp`
       Called when PlayerCharacter collides/triggers with key, used to unlock/remove the "locks"

- State machine, in `Turret.cs` in `class Turret` as `TurretState _state`
  TurretStates can call ChangeState in Turret with an enum parameter to change to another state.

- Pool, in `ComponentPool.cs` in `class ComponentPool<T>`
  Creates pools of Components that inherit from `IPoolable<T>`.
  Takes a prefab, parent object etc as arguments.
  Used by Turret to make a Pool of Projectiles.