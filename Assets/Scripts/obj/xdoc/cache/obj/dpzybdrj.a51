id: cs.temp.dll
language: CSharp
name:
  Default: cs.temp.dll
qualifiedName:
  Default: cs.temp.dll
type: Assembly
modifiers: {}
items:
- id: Tetris
  commentId: N:Tetris
  language: CSharp
  name:
    CSharp: Tetris
    VB: Tetris
  nameWithType:
    CSharp: Tetris
    VB: Tetris
  qualifiedName:
    CSharp: Tetris
    VB: Tetris
  type: Namespace
  assemblies:
  - cs.temp.dll
  modifiers: {}
  items:
  - id: Tetris.Blocks
    commentId: T:Tetris.Blocks
    language: CSharp
    name:
      CSharp: Blocks
      VB: Blocks
    nameWithType:
      CSharp: Blocks
      VB: Blocks
    qualifiedName:
      CSharp: Tetris.Blocks
      VB: Tetris.Blocks
    type: Class
    assemblies:
    - cs.temp.dll
    namespace: Tetris
    source:
      id: Blocks
      path: ''
      startLine: 9
    syntax:
      content:
        CSharp: 'public class Blocks : MonoBehaviour'
        VB: >-
          Public Class Blocks

              Inherits MonoBehaviour
    inheritance:
    - System.Object
    modifiers:
      CSharp:
      - public
      - class
      VB:
      - Public
      - Class
    items:
    - id: Tetris.Blocks.IsFalling
      commentId: F:Tetris.Blocks.IsFalling
      language: CSharp
      name:
        CSharp: IsFalling
        VB: IsFalling
      nameWithType:
        CSharp: Blocks.IsFalling
        VB: Blocks.IsFalling
      qualifiedName:
        CSharp: Tetris.Blocks.IsFalling
        VB: Tetris.Blocks.IsFalling
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsFalling
        path: ''
        startLine: 12
      syntax:
        content:
          CSharp: public static List<bool> IsFalling
          VB: Public Shared IsFalling As List(Of Boolean)
        return:
          type: System.Collections.Generic.List{System.Boolean}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.ActiveSpawn
      commentId: F:Tetris.Blocks.ActiveSpawn
      language: CSharp
      name:
        CSharp: ActiveSpawn
        VB: ActiveSpawn
      nameWithType:
        CSharp: Blocks.ActiveSpawn
        VB: Blocks.ActiveSpawn
      qualifiedName:
        CSharp: Tetris.Blocks.ActiveSpawn
        VB: Tetris.Blocks.ActiveSpawn
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: ActiveSpawn
        path: ''
        startLine: 13
      syntax:
        content:
          CSharp: public static List<bool> ActiveSpawn
          VB: Public Shared ActiveSpawn As List(Of Boolean)
        return:
          type: System.Collections.Generic.List{System.Boolean}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.blockPrefab
      commentId: F:Tetris.Blocks.blockPrefab
      language: CSharp
      name:
        CSharp: blockPrefab
        VB: blockPrefab
      nameWithType:
        CSharp: Blocks.blockPrefab
        VB: Blocks.blockPrefab
      qualifiedName:
        CSharp: Tetris.Blocks.blockPrefab
        VB: Tetris.Blocks.blockPrefab
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: blockPrefab
        path: ''
        startLine: 18
      syntax:
        content:
          CSharp: public GameObject blockPrefab
          VB: Public blockPrefab As GameObject
        return:
          type: GameObject
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.randomType
      commentId: F:Tetris.Blocks.randomType
      language: CSharp
      name:
        CSharp: randomType
        VB: randomType
      nameWithType:
        CSharp: Blocks.randomType
        VB: Blocks.randomType
      qualifiedName:
        CSharp: Tetris.Blocks.randomType
        VB: Tetris.Blocks.randomType
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: randomType
        path: ''
        startLine: 20
      syntax:
        content:
          CSharp: public string[] randomType
          VB: Public randomType As String()
        return:
          type: System.String[]
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.timeFall
      commentId: F:Tetris.Blocks.timeFall
      language: CSharp
      name:
        CSharp: timeFall
        VB: timeFall
      nameWithType:
        CSharp: Blocks.timeFall
        VB: Blocks.timeFall
      qualifiedName:
        CSharp: Tetris.Blocks.timeFall
        VB: Tetris.Blocks.timeFall
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: timeFall
        path: ''
        startLine: 26
      syntax:
        content:
          CSharp: public List<float> timeFall
          VB: Public timeFall As List(Of Single)
        return:
          type: System.Collections.Generic.List{System.Single}
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.TimeToFall
      commentId: F:Tetris.Blocks.TimeToFall
      language: CSharp
      name:
        CSharp: TimeToFall
        VB: TimeToFall
      nameWithType:
        CSharp: Blocks.TimeToFall
        VB: Blocks.TimeToFall
      qualifiedName:
        CSharp: Tetris.Blocks.TimeToFall
        VB: Tetris.Blocks.TimeToFall
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: TimeToFall
        path: ''
        startLine: 27
      syntax:
        content:
          CSharp: public static float TimeToFall
          VB: Public Shared TimeToFall As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.timeAutoRepeat
      commentId: F:Tetris.Blocks.timeAutoRepeat
      language: CSharp
      name:
        CSharp: timeAutoRepeat
        VB: timeAutoRepeat
      nameWithType:
        CSharp: Blocks.timeAutoRepeat
        VB: Blocks.timeAutoRepeat
      qualifiedName:
        CSharp: Tetris.Blocks.timeAutoRepeat
        VB: Tetris.Blocks.timeAutoRepeat
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: timeAutoRepeat
        path: ''
        startLine: 30
      syntax:
        content:
          CSharp: public List<float> timeAutoRepeat
          VB: Public timeAutoRepeat As List(Of Single)
        return:
          type: System.Collections.Generic.List{System.Single}
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.timeToAutoRepeat
      commentId: F:Tetris.Blocks.timeToAutoRepeat
      language: CSharp
      name:
        CSharp: timeToAutoRepeat
        VB: timeToAutoRepeat
      nameWithType:
        CSharp: Blocks.timeToAutoRepeat
        VB: Blocks.timeToAutoRepeat
      qualifiedName:
        CSharp: Tetris.Blocks.timeToAutoRepeat
        VB: Tetris.Blocks.timeToAutoRepeat
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: timeToAutoRepeat
        path: ''
        startLine: 31
      syntax:
        content:
          CSharp: public float timeToAutoRepeat
          VB: Public timeToAutoRepeat As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.TimeLock
      commentId: F:Tetris.Blocks.TimeLock
      language: CSharp
      name:
        CSharp: TimeLock
        VB: TimeLock
      nameWithType:
        CSharp: Blocks.TimeLock
        VB: Blocks.TimeLock
      qualifiedName:
        CSharp: Tetris.Blocks.TimeLock
        VB: Tetris.Blocks.TimeLock
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: TimeLock
        path: ''
        startLine: 34
      syntax:
        content:
          CSharp: public static List<float> TimeLock
          VB: Public Shared TimeLock As List(Of Single)
        return:
          type: System.Collections.Generic.List{System.Single}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.timeToLock
      commentId: F:Tetris.Blocks.timeToLock
      language: CSharp
      name:
        CSharp: timeToLock
        VB: timeToLock
      nameWithType:
        CSharp: Blocks.timeToLock
        VB: Blocks.timeToLock
      qualifiedName:
        CSharp: Tetris.Blocks.timeToLock
        VB: Tetris.Blocks.timeToLock
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: timeToLock
        path: ''
        startLine: 35
      syntax:
        content:
          CSharp: public float timeToLock
          VB: Public timeToLock As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.LockCounter
      commentId: F:Tetris.Blocks.LockCounter
      language: CSharp
      name:
        CSharp: LockCounter
        VB: LockCounter
      nameWithType:
        CSharp: Blocks.LockCounter
        VB: Blocks.LockCounter
      qualifiedName:
        CSharp: Tetris.Blocks.LockCounter
        VB: Tetris.Blocks.LockCounter
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: LockCounter
        path: ''
        startLine: 36
      syntax:
        content:
          CSharp: public static List<int> LockCounter
          VB: Public Shared LockCounter As List(Of Integer)
        return:
          type: System.Collections.Generic.List{System.Int32}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.lockDeepestRow
      commentId: F:Tetris.Blocks.lockDeepestRow
      language: CSharp
      name:
        CSharp: lockDeepestRow
        VB: lockDeepestRow
      nameWithType:
        CSharp: Blocks.lockDeepestRow
        VB: Blocks.lockDeepestRow
      qualifiedName:
        CSharp: Tetris.Blocks.lockDeepestRow
        VB: Tetris.Blocks.lockDeepestRow
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: lockDeepestRow
        path: ''
        startLine: 37
      syntax:
        content:
          CSharp: public List<int> lockDeepestRow
          VB: Public lockDeepestRow As List(Of Integer)
        return:
          type: System.Collections.Generic.List{System.Int32}
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.timeBeginAutoRepeat
      commentId: F:Tetris.Blocks.timeBeginAutoRepeat
      language: CSharp
      name:
        CSharp: timeBeginAutoRepeat
        VB: timeBeginAutoRepeat
      nameWithType:
        CSharp: Blocks.timeBeginAutoRepeat
        VB: Blocks.timeBeginAutoRepeat
      qualifiedName:
        CSharp: Tetris.Blocks.timeBeginAutoRepeat
        VB: Tetris.Blocks.timeBeginAutoRepeat
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: timeBeginAutoRepeat
        path: ''
        startLine: 40
      syntax:
        content:
          CSharp: public List<float> timeBeginAutoRepeat
          VB: Public timeBeginAutoRepeat As List(Of Single)
        return:
          type: System.Collections.Generic.List{System.Single}
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.timeToBeginAutoRepeat
      commentId: F:Tetris.Blocks.timeToBeginAutoRepeat
      language: CSharp
      name:
        CSharp: timeToBeginAutoRepeat
        VB: timeToBeginAutoRepeat
      nameWithType:
        CSharp: Blocks.timeToBeginAutoRepeat
        VB: Blocks.timeToBeginAutoRepeat
      qualifiedName:
        CSharp: Tetris.Blocks.timeToBeginAutoRepeat
        VB: Tetris.Blocks.timeToBeginAutoRepeat
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: timeToBeginAutoRepeat
        path: ''
        startLine: 41
      syntax:
        content:
          CSharp: public float timeToBeginAutoRepeat
          VB: Public timeToBeginAutoRepeat As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.lastDir
      commentId: F:Tetris.Blocks.lastDir
      language: CSharp
      name:
        CSharp: lastDir
        VB: lastDir
      nameWithType:
        CSharp: Blocks.lastDir
        VB: Blocks.lastDir
      qualifiedName:
        CSharp: Tetris.Blocks.lastDir
        VB: Tetris.Blocks.lastDir
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: lastDir
        path: ''
        startLine: 42
      syntax:
        content:
          CSharp: public bool lastDir
          VB: Public lastDir As Boolean
        return:
          type: System.Boolean
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.timeSoftDrop
      commentId: F:Tetris.Blocks.timeSoftDrop
      language: CSharp
      name:
        CSharp: timeSoftDrop
        VB: timeSoftDrop
      nameWithType:
        CSharp: Blocks.timeSoftDrop
        VB: Blocks.timeSoftDrop
      qualifiedName:
        CSharp: Tetris.Blocks.timeSoftDrop
        VB: Tetris.Blocks.timeSoftDrop
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: timeSoftDrop
        path: ''
        startLine: 45
      syntax:
        content:
          CSharp: public List<float> timeSoftDrop
          VB: Public timeSoftDrop As List(Of Single)
        return:
          type: System.Collections.Generic.List{System.Single}
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.timeToSoftDrop
      commentId: F:Tetris.Blocks.timeToSoftDrop
      language: CSharp
      name:
        CSharp: timeToSoftDrop
        VB: timeToSoftDrop
      nameWithType:
        CSharp: Blocks.timeToSoftDrop
        VB: Blocks.timeToSoftDrop
      qualifiedName:
        CSharp: Tetris.Blocks.timeToSoftDrop
        VB: Tetris.Blocks.timeToSoftDrop
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: timeToSoftDrop
        path: ''
        startLine: 46
      syntax:
        content:
          CSharp: public float timeToSoftDrop
          VB: Public timeToSoftDrop As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.PreviewBlock
      commentId: F:Tetris.Blocks.PreviewBlock
      language: CSharp
      name:
        CSharp: PreviewBlock
        VB: PreviewBlock
      nameWithType:
        CSharp: Blocks.PreviewBlock
        VB: Blocks.PreviewBlock
      qualifiedName:
        CSharp: Tetris.Blocks.PreviewBlock
        VB: Tetris.Blocks.PreviewBlock
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: PreviewBlock
        path: ''
        startLine: 49
      syntax:
        content:
          CSharp: public static List<GameObject> PreviewBlock
          VB: Public Shared PreviewBlock As List(Of GameObject)
        return:
          type: System.Collections.Generic.List{GameObject}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.HoldType
      commentId: F:Tetris.Blocks.HoldType
      language: CSharp
      name:
        CSharp: HoldType
        VB: HoldType
      nameWithType:
        CSharp: Blocks.HoldType
        VB: Blocks.HoldType
      qualifiedName:
        CSharp: Tetris.Blocks.HoldType
        VB: Tetris.Blocks.HoldType
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: HoldType
        path: ''
        startLine: 54
      syntax:
        content:
          CSharp: public static string[] HoldType
          VB: Public Shared HoldType As String()
        return:
          type: System.String[]
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.holdUsed
      commentId: F:Tetris.Blocks.holdUsed
      language: CSharp
      name:
        CSharp: holdUsed
        VB: holdUsed
      nameWithType:
        CSharp: Blocks.holdUsed
        VB: Blocks.holdUsed
      qualifiedName:
        CSharp: Tetris.Blocks.holdUsed
        VB: Tetris.Blocks.holdUsed
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: holdUsed
        path: ''
        startLine: 55
      syntax:
        content:
          CSharp: public List<bool> holdUsed
          VB: Public holdUsed As List(Of Boolean)
        return:
          type: System.Collections.Generic.List{System.Boolean}
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.holdSpawn
      commentId: F:Tetris.Blocks.holdSpawn
      language: CSharp
      name:
        CSharp: holdSpawn
        VB: holdSpawn
      nameWithType:
        CSharp: Blocks.holdSpawn
        VB: Blocks.holdSpawn
      qualifiedName:
        CSharp: Tetris.Blocks.holdSpawn
        VB: Tetris.Blocks.holdSpawn
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: holdSpawn
        path: ''
        startLine: 56
      syntax:
        content:
          CSharp: public List<bool> holdSpawn
          VB: Public holdSpawn As List(Of Boolean)
        return:
          type: System.Collections.Generic.List{System.Boolean}
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.HoldBlock
      commentId: F:Tetris.Blocks.HoldBlock
      language: CSharp
      name:
        CSharp: HoldBlock
        VB: HoldBlock
      nameWithType:
        CSharp: Blocks.HoldBlock
        VB: Blocks.HoldBlock
      qualifiedName:
        CSharp: Tetris.Blocks.HoldBlock
        VB: Tetris.Blocks.HoldBlock
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: HoldBlock
        path: ''
        startLine: 57
      syntax:
        content:
          CSharp: public static List<GameObject> HoldBlock
          VB: Public Shared HoldBlock As List(Of GameObject)
        return:
          type: System.Collections.Generic.List{GameObject}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.move
      commentId: F:Tetris.Blocks.move
      language: CSharp
      name:
        CSharp: move
        VB: move
      nameWithType:
        CSharp: Blocks.move
        VB: Blocks.move
      qualifiedName:
        CSharp: Tetris.Blocks.move
        VB: Tetris.Blocks.move
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: move
        path: ''
        startLine: 60
      syntax:
        content:
          CSharp: public bool move
          VB: Public move As Boolean
        return:
          type: System.Boolean
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.spawn
      commentId: F:Tetris.Blocks.spawn
      language: CSharp
      name:
        CSharp: spawn
        VB: spawn
      nameWithType:
        CSharp: Blocks.spawn
        VB: Blocks.spawn
      qualifiedName:
        CSharp: Tetris.Blocks.spawn
        VB: Tetris.Blocks.spawn
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: spawn
        path: ''
        startLine: 61
      syntax:
        content:
          CSharp: public bool spawn
          VB: Public spawn As Boolean
        return:
          type: System.Boolean
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.KeybindRight
      commentId: F:Tetris.Blocks.KeybindRight
      language: CSharp
      name:
        CSharp: KeybindRight
        VB: KeybindRight
      nameWithType:
        CSharp: Blocks.KeybindRight
        VB: Blocks.KeybindRight
      qualifiedName:
        CSharp: Tetris.Blocks.KeybindRight
        VB: Tetris.Blocks.KeybindRight
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: KeybindRight
        path: ''
        startLine: 64
      syntax:
        content:
          CSharp: public static string[] KeybindRight
          VB: Public Shared KeybindRight As String()
        return:
          type: System.String[]
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.KeybindLeft
      commentId: F:Tetris.Blocks.KeybindLeft
      language: CSharp
      name:
        CSharp: KeybindLeft
        VB: KeybindLeft
      nameWithType:
        CSharp: Blocks.KeybindLeft
        VB: Blocks.KeybindLeft
      qualifiedName:
        CSharp: Tetris.Blocks.KeybindLeft
        VB: Tetris.Blocks.KeybindLeft
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: KeybindLeft
        path: ''
        startLine: 65
      syntax:
        content:
          CSharp: public static string[] KeybindLeft
          VB: Public Shared KeybindLeft As String()
        return:
          type: System.String[]
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.KeybindSoftDrop
      commentId: F:Tetris.Blocks.KeybindSoftDrop
      language: CSharp
      name:
        CSharp: KeybindSoftDrop
        VB: KeybindSoftDrop
      nameWithType:
        CSharp: Blocks.KeybindSoftDrop
        VB: Blocks.KeybindSoftDrop
      qualifiedName:
        CSharp: Tetris.Blocks.KeybindSoftDrop
        VB: Tetris.Blocks.KeybindSoftDrop
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: KeybindSoftDrop
        path: ''
        startLine: 66
      syntax:
        content:
          CSharp: public static string[] KeybindSoftDrop
          VB: Public Shared KeybindSoftDrop As String()
        return:
          type: System.String[]
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.KeybindHardDrop
      commentId: F:Tetris.Blocks.KeybindHardDrop
      language: CSharp
      name:
        CSharp: KeybindHardDrop
        VB: KeybindHardDrop
      nameWithType:
        CSharp: Blocks.KeybindHardDrop
        VB: Blocks.KeybindHardDrop
      qualifiedName:
        CSharp: Tetris.Blocks.KeybindHardDrop
        VB: Tetris.Blocks.KeybindHardDrop
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: KeybindHardDrop
        path: ''
        startLine: 67
      syntax:
        content:
          CSharp: public static string[] KeybindHardDrop
          VB: Public Shared KeybindHardDrop As String()
        return:
          type: System.String[]
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.KeybindHold
      commentId: F:Tetris.Blocks.KeybindHold
      language: CSharp
      name:
        CSharp: KeybindHold
        VB: KeybindHold
      nameWithType:
        CSharp: Blocks.KeybindHold
        VB: Blocks.KeybindHold
      qualifiedName:
        CSharp: Tetris.Blocks.KeybindHold
        VB: Tetris.Blocks.KeybindHold
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: KeybindHold
        path: ''
        startLine: 68
      syntax:
        content:
          CSharp: public static string[] KeybindHold
          VB: Public Shared KeybindHold As String()
        return:
          type: System.String[]
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.playerIds
      commentId: F:Tetris.Blocks.playerIds
      language: CSharp
      name:
        CSharp: playerIds
        VB: playerIds
      nameWithType:
        CSharp: Blocks.playerIds
        VB: Blocks.playerIds
      qualifiedName:
        CSharp: Tetris.Blocks.playerIds
        VB: Tetris.Blocks.playerIds
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: playerIds
        path: ''
        startLine: 71
      syntax:
        content:
          CSharp: public static List<int> playerIds
          VB: Public Shared playerIds As List(Of Integer)
        return:
          type: System.Collections.Generic.List{System.Int32}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.rIndex
      commentId: F:Tetris.Blocks.rIndex
      language: CSharp
      name:
        CSharp: rIndex
        VB: rIndex
      nameWithType:
        CSharp: Blocks.rIndex
        VB: Blocks.rIndex
      qualifiedName:
        CSharp: Tetris.Blocks.rIndex
        VB: Tetris.Blocks.rIndex
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: rIndex
        path: ''
        startLine: 74
      syntax:
        content:
          CSharp: public int rIndex
          VB: Public rIndex As Integer
        return:
          type: System.Int32
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.lineClearCoroutine
      commentId: F:Tetris.Blocks.lineClearCoroutine
      language: CSharp
      name:
        CSharp: lineClearCoroutine
        VB: lineClearCoroutine
      nameWithType:
        CSharp: Blocks.lineClearCoroutine
        VB: Blocks.lineClearCoroutine
      qualifiedName:
        CSharp: Tetris.Blocks.lineClearCoroutine
        VB: Tetris.Blocks.lineClearCoroutine
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: lineClearCoroutine
        path: ''
        startLine: 79
      syntax:
        content:
          CSharp: public bool lineClearCoroutine
          VB: Public lineClearCoroutine As Boolean
        return:
          type: System.Boolean
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.SpawnArea
      commentId: F:Tetris.Blocks.SpawnArea
      language: CSharp
      name:
        CSharp: SpawnArea
        VB: SpawnArea
      nameWithType:
        CSharp: Blocks.SpawnArea
        VB: Blocks.SpawnArea
      qualifiedName:
        CSharp: Tetris.Blocks.SpawnArea
        VB: Tetris.Blocks.SpawnArea
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: SpawnArea
        path: ''
        startLine: 82
      syntax:
        content:
          CSharp: public static Vector3 SpawnArea
          VB: Public Shared SpawnArea As Vector3
        return:
          type: Vector3
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.StartArea
      commentId: F:Tetris.Blocks.StartArea
      language: CSharp
      name:
        CSharp: StartArea
        VB: StartArea
      nameWithType:
        CSharp: Blocks.StartArea
        VB: Blocks.StartArea
      qualifiedName:
        CSharp: Tetris.Blocks.StartArea
        VB: Tetris.Blocks.StartArea
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: StartArea
        path: ''
        startLine: 85
      syntax:
        content:
          CSharp: public static List<Vector3> StartArea
          VB: Public Shared StartArea As List(Of Vector3)
        return:
          type: System.Collections.Generic.List{Vector3}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.PreviewArea
      commentId: F:Tetris.Blocks.PreviewArea
      language: CSharp
      name:
        CSharp: PreviewArea
        VB: PreviewArea
      nameWithType:
        CSharp: Blocks.PreviewArea
        VB: Blocks.PreviewArea
      qualifiedName:
        CSharp: Tetris.Blocks.PreviewArea
        VB: Tetris.Blocks.PreviewArea
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: PreviewArea
        path: ''
        startLine: 88
      syntax:
        content:
          CSharp: public static List<Vector3> PreviewArea
          VB: Public Shared PreviewArea As List(Of Vector3)
        return:
          type: System.Collections.Generic.List{Vector3}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.HoldArea
      commentId: F:Tetris.Blocks.HoldArea
      language: CSharp
      name:
        CSharp: HoldArea
        VB: HoldArea
      nameWithType:
        CSharp: Blocks.HoldArea
        VB: Blocks.HoldArea
      qualifiedName:
        CSharp: Tetris.Blocks.HoldArea
        VB: Tetris.Blocks.HoldArea
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: HoldArea
        path: ''
        startLine: 91
      syntax:
        content:
          CSharp: public static List<Vector3> HoldArea
          VB: Public Shared HoldArea As List(Of Vector3)
        return:
          type: System.Collections.Generic.List{Vector3}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Blocks.Tetrominos
      commentId: F:Tetris.Blocks.Tetrominos
      language: CSharp
      name:
        CSharp: Tetrominos
        VB: Tetrominos
      nameWithType:
        CSharp: Blocks.Tetrominos
        VB: Blocks.Tetrominos
      qualifiedName:
        CSharp: Tetris.Blocks.Tetrominos
        VB: Tetris.Blocks.Tetrominos
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Tetrominos
        path: ''
        startLine: 94
      syntax:
        content:
          CSharp: public static readonly List<Tetromino> Tetrominos
          VB: Public Shared ReadOnly Tetrominos As List(Of Tetromino)
        return:
          type: System.Collections.Generic.List{Tetris.Tetromino}
      modifiers:
        CSharp:
        - public
        - static
        - readonly
        VB:
        - Public
        - Shared
        - ReadOnly
    - id: Tetris.Blocks.otherMat
      commentId: F:Tetris.Blocks.otherMat
      language: CSharp
      name:
        CSharp: otherMat
        VB: otherMat
      nameWithType:
        CSharp: Blocks.otherMat
        VB: Blocks.otherMat
      qualifiedName:
        CSharp: Tetris.Blocks.otherMat
        VB: Tetris.Blocks.otherMat
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: otherMat
        path: ''
        startLine: 99
      syntax:
        content:
          CSharp: public Material otherMat
          VB: Public otherMat As Material
        return:
          type: Material
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.InitializePlayer(System.Int32)
      commentId: M:Tetris.Blocks.InitializePlayer(System.Int32)
      language: CSharp
      name:
        CSharp: InitializePlayer(Int32)
        VB: InitializePlayer(Int32)
      nameWithType:
        CSharp: Blocks.InitializePlayer(Int32)
        VB: Blocks.InitializePlayer(Int32)
      qualifiedName:
        CSharp: Tetris.Blocks.InitializePlayer(System.Int32)
        VB: Tetris.Blocks.InitializePlayer(System.Int32)
      type: Method
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: InitializePlayer
        path: ''
        startLine: 136
      syntax:
        content:
          CSharp: public void InitializePlayer(int playerId)
          VB: Public Sub InitializePlayer(playerId As Integer)
        parameters:
        - id: playerId
          type: System.Int32
      overload: Tetris.Blocks.InitializePlayer*
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.RemovePlayer(System.Int32)
      commentId: M:Tetris.Blocks.RemovePlayer(System.Int32)
      language: CSharp
      name:
        CSharp: RemovePlayer(Int32)
        VB: RemovePlayer(Int32)
      nameWithType:
        CSharp: Blocks.RemovePlayer(Int32)
        VB: Blocks.RemovePlayer(Int32)
      qualifiedName:
        CSharp: Tetris.Blocks.RemovePlayer(System.Int32)
        VB: Tetris.Blocks.RemovePlayer(System.Int32)
      type: Method
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: RemovePlayer
        path: ''
        startLine: 164
      syntax:
        content:
          CSharp: public void RemovePlayer(int playerId)
          VB: Public Sub RemovePlayer(playerId As Integer)
        parameters:
        - id: playerId
          type: System.Int32
      overload: Tetris.Blocks.RemovePlayer*
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Blocks.SpawnMino(System.Int32,System.String)
      commentId: M:Tetris.Blocks.SpawnMino(System.Int32,System.String)
      language: CSharp
      name:
        CSharp: SpawnMino(Int32, String)
        VB: SpawnMino(Int32, String)
      nameWithType:
        CSharp: Blocks.SpawnMino(Int32, String)
        VB: Blocks.SpawnMino(Int32, String)
      qualifiedName:
        CSharp: Tetris.Blocks.SpawnMino(System.Int32, System.String)
        VB: Tetris.Blocks.SpawnMino(System.Int32, System.String)
      type: Method
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: SpawnMino
        path: ''
        startLine: 549
      summary: "\nSpawns a block\n"
      example: []
      syntax:
        content:
          CSharp: protected void SpawnMino(int playerId, string type)
          VB: Protected Sub SpawnMino(playerId As Integer, type As String)
        parameters:
        - id: playerId
          type: System.Int32
          description: corresponding player id
        - id: type
          type: System.String
          description: type of a block
      overload: Tetris.Blocks.SpawnMino*
      modifiers:
        CSharp:
        - protected
        VB:
        - Protected
  - id: Tetris.Menu
    commentId: T:Tetris.Menu
    language: CSharp
    name:
      CSharp: Menu
      VB: Menu
    nameWithType:
      CSharp: Menu
      VB: Menu
    qualifiedName:
      CSharp: Tetris.Menu
      VB: Tetris.Menu
    type: Class
    assemblies:
    - cs.temp.dll
    namespace: Tetris
    source:
      id: Menu
      path: ''
      startLine: 879
    syntax:
      content:
        CSharp: 'public class Menu : MonoBehaviour'
        VB: >-
          Public Class Menu

              Inherits MonoBehaviour
    inheritance:
    - System.Object
    modifiers:
      CSharp:
      - public
      - class
      VB:
      - Public
      - Class
    items:
    - id: Tetris.Menu.materialMenu
      commentId: F:Tetris.Menu.materialMenu
      language: CSharp
      name:
        CSharp: materialMenu
        VB: materialMenu
      nameWithType:
        CSharp: Menu.materialMenu
        VB: Menu.materialMenu
      qualifiedName:
        CSharp: Tetris.Menu.materialMenu
        VB: Tetris.Menu.materialMenu
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: materialMenu
        path: ''
        startLine: 883
      syntax:
        content:
          CSharp: public Material materialMenu
          VB: Public materialMenu As Material
        return:
          type: Material
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Menu.materialGame
      commentId: F:Tetris.Menu.materialGame
      language: CSharp
      name:
        CSharp: materialGame
        VB: materialGame
      nameWithType:
        CSharp: Menu.materialGame
        VB: Menu.materialGame
      qualifiedName:
        CSharp: Tetris.Menu.materialGame
        VB: Tetris.Menu.materialGame
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: materialGame
        path: ''
        startLine: 884
      syntax:
        content:
          CSharp: public Material materialGame
          VB: Public materialGame As Material
        return:
          type: Material
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Menu.blockPrefab2
      commentId: F:Tetris.Menu.blockPrefab2
      language: CSharp
      name:
        CSharp: blockPrefab2
        VB: blockPrefab2
      nameWithType:
        CSharp: Menu.blockPrefab2
        VB: Menu.blockPrefab2
      qualifiedName:
        CSharp: Tetris.Menu.blockPrefab2
        VB: Tetris.Menu.blockPrefab2
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: blockPrefab2
        path: ''
        startLine: 885
      syntax:
        content:
          CSharp: public GameObject blockPrefab2
          VB: Public blockPrefab2 As GameObject
        return:
          type: GameObject
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Menu.Menus
      commentId: P:Tetris.Menu.Menus
      language: CSharp
      name:
        CSharp: Menus
        VB: Menus
      nameWithType:
        CSharp: Menu.Menus
        VB: Menu.Menus
      qualifiedName:
        CSharp: Tetris.Menu.Menus
        VB: Tetris.Menu.Menus
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Menus
        path: ''
        startLine: 902
      syntax:
        content:
          CSharp: public static SubMenu[] Menus { get; }
          VB: Public Shared ReadOnly Property Menus As SubMenu()
        parameters: []
        return:
          type: Tetris.SubMenu[]
      overload: Tetris.Menu.Menus*
      modifiers:
        CSharp:
        - public
        - static
        - get
        VB:
        - Public
        - Shared
        - ReadOnly
    - id: Tetris.Menu.PlayerCount
      commentId: P:Tetris.Menu.PlayerCount
      language: CSharp
      name:
        CSharp: PlayerCount
        VB: PlayerCount
      nameWithType:
        CSharp: Menu.PlayerCount
        VB: Menu.PlayerCount
      qualifiedName:
        CSharp: Tetris.Menu.PlayerCount
        VB: Tetris.Menu.PlayerCount
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: PlayerCount
        path: ''
        startLine: 906
      syntax:
        content:
          CSharp: public int PlayerCount { get; set; }
          VB: Public Property PlayerCount As Integer
        parameters: []
        return:
          type: System.Int32
      overload: Tetris.Menu.PlayerCount*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Menu.NeedToAddPlayer
      commentId: P:Tetris.Menu.NeedToAddPlayer
      language: CSharp
      name:
        CSharp: NeedToAddPlayer
        VB: NeedToAddPlayer
      nameWithType:
        CSharp: Menu.NeedToAddPlayer
        VB: Menu.NeedToAddPlayer
      qualifiedName:
        CSharp: Tetris.Menu.NeedToAddPlayer
        VB: Tetris.Menu.NeedToAddPlayer
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: NeedToAddPlayer
        path: ''
        startLine: 907
      syntax:
        content:
          CSharp: public static bool NeedToAddPlayer { get; set; }
          VB: Public Shared Property NeedToAddPlayer As Boolean
        parameters: []
        return:
          type: System.Boolean
      overload: Tetris.Menu.NeedToAddPlayer*
      modifiers:
        CSharp:
        - public
        - static
        - get
        - set
        VB:
        - Public
        - Shared
    - id: Tetris.Menu.NeedToRemovePlayer
      commentId: P:Tetris.Menu.NeedToRemovePlayer
      language: CSharp
      name:
        CSharp: NeedToRemovePlayer
        VB: NeedToRemovePlayer
      nameWithType:
        CSharp: Menu.NeedToRemovePlayer
        VB: Menu.NeedToRemovePlayer
      qualifiedName:
        CSharp: Tetris.Menu.NeedToRemovePlayer
        VB: Tetris.Menu.NeedToRemovePlayer
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: NeedToRemovePlayer
        path: ''
        startLine: 908
      syntax:
        content:
          CSharp: public static bool NeedToRemovePlayer { get; set; }
          VB: Public Shared Property NeedToRemovePlayer As Boolean
        parameters: []
        return:
          type: System.Boolean
      overload: Tetris.Menu.NeedToRemovePlayer*
      modifiers:
        CSharp:
        - public
        - static
        - get
        - set
        VB:
        - Public
        - Shared
  - id: Tetris.Rotation
    commentId: T:Tetris.Rotation
    language: CSharp
    name:
      CSharp: Rotation
      VB: Rotation
    nameWithType:
      CSharp: Rotation
      VB: Rotation
    qualifiedName:
      CSharp: Tetris.Rotation
      VB: Tetris.Rotation
    type: Class
    assemblies:
    - cs.temp.dll
    namespace: Tetris
    source:
      id: Rotation
      path: ''
      startLine: 1430
    syntax:
      content:
        CSharp: 'public class Rotation : MonoBehaviour'
        VB: >-
          Public Class Rotation

              Inherits MonoBehaviour
    inheritance:
    - System.Object
    modifiers:
      CSharp:
      - public
      - class
      VB:
      - Public
      - Class
    items:
    - id: Tetris.Rotation.RotationOffsetX
      commentId: F:Tetris.Rotation.RotationOffsetX
      language: CSharp
      name:
        CSharp: RotationOffsetX
        VB: RotationOffsetX
      nameWithType:
        CSharp: Rotation.RotationOffsetX
        VB: Rotation.RotationOffsetX
      qualifiedName:
        CSharp: Tetris.Rotation.RotationOffsetX
        VB: Tetris.Rotation.RotationOffsetX
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: RotationOffsetX
        path: ''
        startLine: 1432
      syntax:
        content:
          CSharp: public static float RotationOffsetX
          VB: Public Shared RotationOffsetX As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Rotation.RotationOffsetY
      commentId: F:Tetris.Rotation.RotationOffsetY
      language: CSharp
      name:
        CSharp: RotationOffsetY
        VB: RotationOffsetY
      nameWithType:
        CSharp: Rotation.RotationOffsetY
        VB: Rotation.RotationOffsetY
      qualifiedName:
        CSharp: Tetris.Rotation.RotationOffsetY
        VB: Tetris.Rotation.RotationOffsetY
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: RotationOffsetY
        path: ''
        startLine: 1433
      syntax:
        content:
          CSharp: public static float RotationOffsetY
          VB: Public Shared RotationOffsetY As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Rotation.KeybindRotateC
      commentId: F:Tetris.Rotation.KeybindRotateC
      language: CSharp
      name:
        CSharp: KeybindRotateC
        VB: KeybindRotateC
      nameWithType:
        CSharp: Rotation.KeybindRotateC
        VB: Rotation.KeybindRotateC
      qualifiedName:
        CSharp: Tetris.Rotation.KeybindRotateC
        VB: Tetris.Rotation.KeybindRotateC
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: KeybindRotateC
        path: ''
        startLine: 1435
      syntax:
        content:
          CSharp: public static List<string> KeybindRotateC
          VB: Public Shared KeybindRotateC As List(Of String)
        return:
          type: System.Collections.Generic.List{System.String}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Rotation.KeybindRotateAc
      commentId: F:Tetris.Rotation.KeybindRotateAc
      language: CSharp
      name:
        CSharp: KeybindRotateAc
        VB: KeybindRotateAc
      nameWithType:
        CSharp: Rotation.KeybindRotateAc
        VB: Rotation.KeybindRotateAc
      qualifiedName:
        CSharp: Tetris.Rotation.KeybindRotateAc
        VB: Tetris.Rotation.KeybindRotateAc
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: KeybindRotateAc
        path: ''
        startLine: 1436
      syntax:
        content:
          CSharp: public static List<string> KeybindRotateAc
          VB: Public Shared KeybindRotateAc As List(Of String)
        return:
          type: System.Collections.Generic.List{System.String}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Rotation.FutureRotationC
      commentId: F:Tetris.Rotation.FutureRotationC
      language: CSharp
      name:
        CSharp: FutureRotationC
        VB: FutureRotationC
      nameWithType:
        CSharp: Rotation.FutureRotationC
        VB: Rotation.FutureRotationC
      qualifiedName:
        CSharp: Tetris.Rotation.FutureRotationC
        VB: Tetris.Rotation.FutureRotationC
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: FutureRotationC
        path: ''
        startLine: 1439
      syntax:
        content:
          CSharp: public static List<int> FutureRotationC
          VB: Public Shared FutureRotationC As List(Of Integer)
        return:
          type: System.Collections.Generic.List{System.Int32}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Rotation.FutureRotationAc
      commentId: F:Tetris.Rotation.FutureRotationAc
      language: CSharp
      name:
        CSharp: FutureRotationAc
        VB: FutureRotationAc
      nameWithType:
        CSharp: Rotation.FutureRotationAc
        VB: Rotation.FutureRotationAc
      qualifiedName:
        CSharp: Tetris.Rotation.FutureRotationAc
        VB: Tetris.Rotation.FutureRotationAc
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: FutureRotationAc
        path: ''
        startLine: 1440
      syntax:
        content:
          CSharp: public static List<int> FutureRotationAc
          VB: Public Shared FutureRotationAc As List(Of Integer)
        return:
          type: System.Collections.Generic.List{System.Int32}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Rotation.RGridCache
      commentId: P:Tetris.Rotation.RGridCache
      language: CSharp
      name:
        CSharp: RGridCache
        VB: RGridCache
      nameWithType:
        CSharp: Rotation.RGridCache
        VB: Rotation.RGridCache
      qualifiedName:
        CSharp: Tetris.Rotation.RGridCache
        VB: Tetris.Rotation.RGridCache
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: RGridCache
        path: ''
        startLine: 1441
      syntax:
        content:
          CSharp: public static int[, ] RGridCache { get; set; }
          VB: Public Shared Property RGridCache As Integer(,)
        parameters: []
        return:
          type: System.Int32[,]
      overload: Tetris.Rotation.RGridCache*
      modifiers:
        CSharp:
        - public
        - static
        - get
        - set
        VB:
        - Public
        - Shared
    - id: Tetris.Rotation.CanRotate(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
      commentId: M:Tetris.Rotation.CanRotate(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
      language: CSharp
      name:
        CSharp: CanRotate(Int32, Int32, Int32, Int32, Int32)
        VB: CanRotate(Int32, Int32, Int32, Int32, Int32)
      nameWithType:
        CSharp: Rotation.CanRotate(Int32, Int32, Int32, Int32, Int32)
        VB: Rotation.CanRotate(Int32, Int32, Int32, Int32, Int32)
      qualifiedName:
        CSharp: Tetris.Rotation.CanRotate(System.Int32, System.Int32, System.Int32, System.Int32, System.Int32)
        VB: Tetris.Rotation.CanRotate(System.Int32, System.Int32, System.Int32, System.Int32, System.Int32)
      type: Method
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: CanRotate
        path: ''
        startLine: 1443
      syntax:
        content:
          CSharp: public static bool CanRotate(int playerId, int fromState, int intoState, int xOffset, int yOffset)
          VB: Public Shared Function CanRotate(playerId As Integer, fromState As Integer, intoState As Integer, xOffset As Integer, yOffset As Integer) As Boolean
        parameters:
        - id: playerId
          type: System.Int32
        - id: fromState
          type: System.Int32
        - id: intoState
          type: System.Int32
        - id: xOffset
          type: System.Int32
        - id: yOffset
          type: System.Int32
        return:
          type: System.Boolean
      overload: Tetris.Rotation.CanRotate*
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.Rotation.Rotate(System.Int32,System.String,System.Int32,System.Int32)
      commentId: M:Tetris.Rotation.Rotate(System.Int32,System.String,System.Int32,System.Int32)
      language: CSharp
      name:
        CSharp: Rotate(Int32, String, Int32, Int32)
        VB: Rotate(Int32, String, Int32, Int32)
      nameWithType:
        CSharp: Rotation.Rotate(Int32, String, Int32, Int32)
        VB: Rotation.Rotate(Int32, String, Int32, Int32)
      qualifiedName:
        CSharp: Tetris.Rotation.Rotate(System.Int32, System.String, System.Int32, System.Int32)
        VB: Tetris.Rotation.Rotate(System.Int32, System.String, System.Int32, System.Int32)
      type: Method
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Rotate
        path: ''
        startLine: 1919
      syntax:
        content:
          CSharp: public static void Rotate(int playerId, string direction, int xMove, int yMove)
          VB: Public Shared Sub Rotate(playerId As Integer, direction As String, xMove As Integer, yMove As Integer)
        parameters:
        - id: playerId
          type: System.Int32
        - id: direction
          type: System.String
        - id: xMove
          type: System.Int32
        - id: yMove
          type: System.Int32
      overload: Tetris.Rotation.Rotate*
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
  - id: Tetris.ScoreSystem
    commentId: T:Tetris.ScoreSystem
    language: CSharp
    name:
      CSharp: ScoreSystem
      VB: ScoreSystem
    nameWithType:
      CSharp: ScoreSystem
      VB: ScoreSystem
    qualifiedName:
      CSharp: Tetris.ScoreSystem
      VB: Tetris.ScoreSystem
    type: Class
    assemblies:
    - cs.temp.dll
    namespace: Tetris
    source:
      id: ScoreSystem
      path: ''
      startLine: 2062
    summary: "\nScoring system\n"
    example: []
    syntax:
      content:
        CSharp: 'public class ScoreSystem : MonoBehaviour'
        VB: >-
          Public Class ScoreSystem

              Inherits MonoBehaviour
    inheritance:
    - System.Object
    modifiers:
      CSharp:
      - public
      - class
      VB:
      - Public
      - Class
    items:
    - id: Tetris.ScoreSystem.CurrentLevel
      commentId: F:Tetris.ScoreSystem.CurrentLevel
      language: CSharp
      name:
        CSharp: CurrentLevel
        VB: CurrentLevel
      nameWithType:
        CSharp: ScoreSystem.CurrentLevel
        VB: ScoreSystem.CurrentLevel
      qualifiedName:
        CSharp: Tetris.ScoreSystem.CurrentLevel
        VB: Tetris.ScoreSystem.CurrentLevel
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: CurrentLevel
        path: ''
        startLine: 2065
      syntax:
        content:
          CSharp: public static int CurrentLevel
          VB: Public Shared CurrentLevel As Integer
        return:
          type: System.Int32
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.ScoreSystem.CurrentAction
      commentId: F:Tetris.ScoreSystem.CurrentAction
      language: CSharp
      name:
        CSharp: CurrentAction
        VB: CurrentAction
      nameWithType:
        CSharp: ScoreSystem.CurrentAction
        VB: ScoreSystem.CurrentAction
      qualifiedName:
        CSharp: Tetris.ScoreSystem.CurrentAction
        VB: Tetris.ScoreSystem.CurrentAction
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: CurrentAction
        path: ''
        startLine: 2066
      syntax:
        content:
          CSharp: public static float CurrentAction
          VB: Public Shared CurrentAction As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.ScoreSystem.Score
      commentId: F:Tetris.ScoreSystem.Score
      language: CSharp
      name:
        CSharp: Score
        VB: Score
      nameWithType:
        CSharp: ScoreSystem.Score
        VB: ScoreSystem.Score
      qualifiedName:
        CSharp: Tetris.ScoreSystem.Score
        VB: Tetris.ScoreSystem.Score
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Score
        path: ''
        startLine: 2067
      syntax:
        content:
          CSharp: public static float Score
          VB: Public Shared Score As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.ScoreSystem.LinesCleared
      commentId: F:Tetris.ScoreSystem.LinesCleared
      language: CSharp
      name:
        CSharp: LinesCleared
        VB: LinesCleared
      nameWithType:
        CSharp: ScoreSystem.LinesCleared
        VB: ScoreSystem.LinesCleared
      qualifiedName:
        CSharp: Tetris.ScoreSystem.LinesCleared
        VB: Tetris.ScoreSystem.LinesCleared
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: LinesCleared
        path: ''
        startLine: 2069
      syntax:
        content:
          CSharp: public static float LinesCleared
          VB: Public Shared LinesCleared As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.ScoreSystem.IsTSpinLastMove
      commentId: F:Tetris.ScoreSystem.IsTSpinLastMove
      language: CSharp
      name:
        CSharp: IsTSpinLastMove
        VB: IsTSpinLastMove
      nameWithType:
        CSharp: ScoreSystem.IsTSpinLastMove
        VB: ScoreSystem.IsTSpinLastMove
      qualifiedName:
        CSharp: Tetris.ScoreSystem.IsTSpinLastMove
        VB: Tetris.ScoreSystem.IsTSpinLastMove
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsTSpinLastMove
        path: ''
        startLine: 2070
      syntax:
        content:
          CSharp: public static int IsTSpinLastMove
          VB: Public Shared IsTSpinLastMove As Integer
        return:
          type: System.Int32
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.ScoreSystem.IsB2B
      commentId: F:Tetris.ScoreSystem.IsB2B
      language: CSharp
      name:
        CSharp: IsB2B
        VB: IsB2B
      nameWithType:
        CSharp: ScoreSystem.IsB2B
        VB: ScoreSystem.IsB2B
      qualifiedName:
        CSharp: Tetris.ScoreSystem.IsB2B
        VB: Tetris.ScoreSystem.IsB2B
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsB2B
        path: ''
        startLine: 2071
      syntax:
        content:
          CSharp: public static bool IsB2B
          VB: Public Shared IsB2B As Boolean
        return:
          type: System.Boolean
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.ScoreSystem.NewRecordText
      commentId: F:Tetris.ScoreSystem.NewRecordText
      language: CSharp
      name:
        CSharp: NewRecordText
        VB: NewRecordText
      nameWithType:
        CSharp: ScoreSystem.NewRecordText
        VB: ScoreSystem.NewRecordText
      qualifiedName:
        CSharp: Tetris.ScoreSystem.NewRecordText
        VB: Tetris.ScoreSystem.NewRecordText
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: NewRecordText
        path: ''
        startLine: 2072
      syntax:
        content:
          CSharp: public static Text NewRecordText
          VB: Public Shared NewRecordText As Text
        return:
          type: Text
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.ScoreSystem.IsGameOverScoreSet
      commentId: F:Tetris.ScoreSystem.IsGameOverScoreSet
      language: CSharp
      name:
        CSharp: IsGameOverScoreSet
        VB: IsGameOverScoreSet
      nameWithType:
        CSharp: ScoreSystem.IsGameOverScoreSet
        VB: ScoreSystem.IsGameOverScoreSet
      qualifiedName:
        CSharp: Tetris.ScoreSystem.IsGameOverScoreSet
        VB: Tetris.ScoreSystem.IsGameOverScoreSet
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsGameOverScoreSet
        path: ''
        startLine: 2073
      syntax:
        content:
          CSharp: public static bool IsGameOverScoreSet
          VB: Public Shared IsGameOverScoreSet As Boolean
        return:
          type: System.Boolean
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.ScoreSystem.ScoreCounter
      commentId: M:Tetris.ScoreSystem.ScoreCounter
      language: CSharp
      name:
        CSharp: ScoreCounter()
        VB: ScoreCounter()
      nameWithType:
        CSharp: ScoreSystem.ScoreCounter()
        VB: ScoreSystem.ScoreCounter()
      qualifiedName:
        CSharp: Tetris.ScoreSystem.ScoreCounter()
        VB: Tetris.ScoreSystem.ScoreCounter()
      type: Method
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: ScoreCounter
        path: ''
        startLine: 2131
      summary: "\nCalculates current level and sets the fall speed based on cleared lines\nCalled at <xref href=\"Tetris.Blocks.SpawnMino(System.Int32%2cSystem.String)\" data-throw-if-not-resolved=\"false\"></xref>\n"
      example: []
      syntax:
        content:
          CSharp: public static void ScoreCounter()
          VB: Public Shared Sub ScoreCounter
      overload: Tetris.ScoreSystem.ScoreCounter*
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
      references:
        Tetris.Blocks.SpawnMino(System.Int32,System.String): 
  - id: Tetris.SubMenu
    commentId: T:Tetris.SubMenu
    language: CSharp
    name:
      CSharp: SubMenu
      VB: SubMenu
    nameWithType:
      CSharp: SubMenu
      VB: SubMenu
    qualifiedName:
      CSharp: Tetris.SubMenu
      VB: Tetris.SubMenu
    type: Class
    assemblies:
    - cs.temp.dll
    namespace: Tetris
    source:
      id: SubMenu
      path: ''
      startLine: 2161
    summary: "\nClass used for each menu\n"
    example: []
    syntax:
      content:
        CSharp: public class SubMenu
        VB: Public Class SubMenu
    inheritance:
    - System.Object
    modifiers:
      CSharp:
      - public
      - class
      VB:
      - Public
      - Class
    items:
    - id: Tetris.SubMenu.Canvas
      commentId: P:Tetris.SubMenu.Canvas
      language: CSharp
      name:
        CSharp: Canvas
        VB: Canvas
      nameWithType:
        CSharp: SubMenu.Canvas
        VB: SubMenu.Canvas
      qualifiedName:
        CSharp: Tetris.SubMenu.Canvas
        VB: Tetris.SubMenu.Canvas
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Canvas
        path: ''
        startLine: 2166
      summary: "\nGets the Canvas&apos;s parent GameObject\n"
      example: []
      syntax:
        content:
          CSharp: public GameObject Canvas { get; set; }
          VB: Public Property Canvas As GameObject
        parameters: []
        return:
          type: GameObject
      overload: Tetris.SubMenu.Canvas*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.SubMenu.CanvasCanvas
      commentId: P:Tetris.SubMenu.CanvasCanvas
      language: CSharp
      name:
        CSharp: CanvasCanvas
        VB: CanvasCanvas
      nameWithType:
        CSharp: SubMenu.CanvasCanvas
        VB: SubMenu.CanvasCanvas
      qualifiedName:
        CSharp: Tetris.SubMenu.CanvasCanvas
        VB: Tetris.SubMenu.CanvasCanvas
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: CanvasCanvas
        path: ''
        startLine: 2170
      summary: "\nGets the Canvas \n"
      example: []
      syntax:
        content:
          CSharp: public Canvas CanvasCanvas { get; set; }
          VB: Public Property CanvasCanvas As Canvas
        parameters: []
        return:
          type: Canvas
      overload: Tetris.SubMenu.CanvasCanvas*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.SubMenu.MenuItem
      commentId: P:Tetris.SubMenu.MenuItem
      language: CSharp
      name:
        CSharp: MenuItem
        VB: MenuItem
      nameWithType:
        CSharp: SubMenu.MenuItem
        VB: SubMenu.MenuItem
      qualifiedName:
        CSharp: Tetris.SubMenu.MenuItem
        VB: Tetris.SubMenu.MenuItem
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: MenuItem
        path: ''
        startLine: 2174
      summary: "\nGets the Text of a menu item \n"
      example: []
      syntax:
        content:
          CSharp: public Text[] MenuItem { get; set; }
          VB: Public Property MenuItem As Text()
        parameters: []
        return:
          type: Text[]
      overload: Tetris.SubMenu.MenuItem*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.SubMenu.Menu
      commentId: P:Tetris.SubMenu.Menu
      language: CSharp
      name:
        CSharp: Menu
        VB: Menu
      nameWithType:
        CSharp: SubMenu.Menu
        VB: SubMenu.Menu
      qualifiedName:
        CSharp: Tetris.SubMenu.Menu
        VB: Tetris.SubMenu.Menu
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Menu
        path: ''
        startLine: 2178
      summary: "\nGets the GameObject of a menu item\n"
      example: []
      syntax:
        content:
          CSharp: public GameObject[] Menu { get; set; }
          VB: Public Property Menu As GameObject()
        parameters: []
        return:
          type: GameObject[]
      overload: Tetris.SubMenu.Menu*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.SubMenu.SelectedIndex
      commentId: P:Tetris.SubMenu.SelectedIndex
      language: CSharp
      name:
        CSharp: SelectedIndex
        VB: SelectedIndex
      nameWithType:
        CSharp: SubMenu.SelectedIndex
        VB: SubMenu.SelectedIndex
      qualifiedName:
        CSharp: Tetris.SubMenu.SelectedIndex
        VB: Tetris.SubMenu.SelectedIndex
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: SelectedIndex
        path: ''
        startLine: 2182
      summary: "\nGets index of a currently selected <xref href=\"Tetris.SubMenu.MenuItem\" data-throw-if-not-resolved=\"false\"></xref>\n"
      example: []
      syntax:
        content:
          CSharp: public int SelectedIndex { get; set; }
          VB: Public Property SelectedIndex As Integer
        parameters: []
        return:
          type: System.Int32
      overload: Tetris.SubMenu.SelectedIndex*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
      references:
        Tetris.SubMenu.MenuItem: 
    - id: Tetris.SubMenu.MenuItemSelected
      commentId: P:Tetris.SubMenu.MenuItemSelected
      language: CSharp
      name:
        CSharp: MenuItemSelected
        VB: MenuItemSelected
      nameWithType:
        CSharp: SubMenu.MenuItemSelected
        VB: SubMenu.MenuItemSelected
      qualifiedName:
        CSharp: Tetris.SubMenu.MenuItemSelected
        VB: Tetris.SubMenu.MenuItemSelected
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: MenuItemSelected
        path: ''
        startLine: 2186
      summary: "\nGets the Text of a currently selected <xref href=\"Tetris.SubMenu.MenuItem\" data-throw-if-not-resolved=\"false\"></xref>\n"
      example: []
      syntax:
        content:
          CSharp: public Text MenuItemSelected { get; set; }
          VB: Public Property MenuItemSelected As Text
        parameters: []
        return:
          type: Text
      overload: Tetris.SubMenu.MenuItemSelected*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
      references:
        Tetris.SubMenu.MenuItem: 
    - id: Tetris.SubMenu.MenuItemCount
      commentId: P:Tetris.SubMenu.MenuItemCount
      language: CSharp
      name:
        CSharp: MenuItemCount
        VB: MenuItemCount
      nameWithType:
        CSharp: SubMenu.MenuItemCount
        VB: SubMenu.MenuItemCount
      qualifiedName:
        CSharp: Tetris.SubMenu.MenuItemCount
        VB: Tetris.SubMenu.MenuItemCount
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: MenuItemCount
        path: ''
        startLine: 2190
      summary: "\nGets the number of <xref href=\"Tetris.SubMenu.MenuItem\" data-throw-if-not-resolved=\"false\"></xref>s in the submenu\n"
      example: []
      syntax:
        content:
          CSharp: public int MenuItemCount { get; set; }
          VB: Public Property MenuItemCount As Integer
        parameters: []
        return:
          type: System.Int32
      overload: Tetris.SubMenu.MenuItemCount*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
      references:
        Tetris.SubMenu.MenuItem: 
    - id: Tetris.SubMenu.IsPaused
      commentId: P:Tetris.SubMenu.IsPaused
      language: CSharp
      name:
        CSharp: IsPaused
        VB: IsPaused
      nameWithType:
        CSharp: SubMenu.IsPaused
        VB: SubMenu.IsPaused
      qualifiedName:
        CSharp: Tetris.SubMenu.IsPaused
        VB: Tetris.SubMenu.IsPaused
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsPaused
        path: ''
        startLine: 2194
      summary: "\nGets menu&apos;s pause state\n"
      example: []
      syntax:
        content:
          CSharp: public bool IsPaused { get; set; }
          VB: Public Property IsPaused As Boolean
        parameters: []
        return:
          type: System.Boolean
      overload: Tetris.SubMenu.IsPaused*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
  - id: Tetris.SubTileMap
    commentId: T:Tetris.SubTileMap
    language: CSharp
    name:
      CSharp: SubTileMap
      VB: SubTileMap
    nameWithType:
      CSharp: SubTileMap
      VB: SubTileMap
    qualifiedName:
      CSharp: Tetris.SubTileMap
      VB: Tetris.SubTileMap
    type: Class
    assemblies:
    - cs.temp.dll
    namespace: Tetris
    source:
      id: SubTileMap
      path: ''
      startLine: 2201
    syntax:
      content:
        CSharp: public class SubTileMap
        VB: Public Class SubTileMap
    inheritance:
    - System.Object
    modifiers:
      CSharp:
      - public
      - class
      VB:
      - Public
      - Class
    items:
    - id: Tetris.SubTileMap.IsActive
      commentId: P:Tetris.SubTileMap.IsActive
      language: CSharp
      name:
        CSharp: IsActive
        VB: IsActive
      nameWithType:
        CSharp: SubTileMap.IsActive
        VB: SubTileMap.IsActive
      qualifiedName:
        CSharp: Tetris.SubTileMap.IsActive
        VB: Tetris.SubTileMap.IsActive
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsActive
        path: ''
        startLine: 2203
      syntax:
        content:
          CSharp: public bool[, ] IsActive { get; set; }
          VB: Public Property IsActive As Boolean(,)
        parameters: []
        return:
          type: System.Boolean[,]
      overload: Tetris.SubTileMap.IsActive*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.SubTileMap.Color
      commentId: P:Tetris.SubTileMap.Color
      language: CSharp
      name:
        CSharp: Color
        VB: Color
      nameWithType:
        CSharp: SubTileMap.Color
        VB: SubTileMap.Color
      qualifiedName:
        CSharp: Tetris.SubTileMap.Color
        VB: Tetris.SubTileMap.Color
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Color
        path: ''
        startLine: 2204
      syntax:
        content:
          CSharp: public Color[, ] Color { get; set; }
          VB: Public Property Color As Color(,)
        parameters: []
        return:
          type: Color[,]
      overload: Tetris.SubTileMap.Color*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.SubTileMap.IsClear
      commentId: P:Tetris.SubTileMap.IsClear
      language: CSharp
      name:
        CSharp: IsClear
        VB: IsClear
      nameWithType:
        CSharp: SubTileMap.IsClear
        VB: SubTileMap.IsClear
      qualifiedName:
        CSharp: Tetris.SubTileMap.IsClear
        VB: Tetris.SubTileMap.IsClear
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsClear
        path: ''
        startLine: 2205
      syntax:
        content:
          CSharp: public bool[, ] IsClear { get; set; }
          VB: Public Property IsClear As Boolean(,)
        parameters: []
        return:
          type: System.Boolean[,]
      overload: Tetris.SubTileMap.IsClear*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.SubTileMap.CollisionMap
      commentId: P:Tetris.SubTileMap.CollisionMap
      language: CSharp
      name:
        CSharp: CollisionMap
        VB: CollisionMap
      nameWithType:
        CSharp: SubTileMap.CollisionMap
        VB: SubTileMap.CollisionMap
      qualifiedName:
        CSharp: Tetris.SubTileMap.CollisionMap
        VB: Tetris.SubTileMap.CollisionMap
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: CollisionMap
        path: ''
        startLine: 2206
      syntax:
        content:
          CSharp: public bool[, ] CollisionMap { get; set; }
          VB: Public Property CollisionMap As Boolean(,)
        parameters: []
        return:
          type: System.Boolean[,]
      overload: Tetris.SubTileMap.CollisionMap*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.SubTileMap.GridCube
      commentId: P:Tetris.SubTileMap.GridCube
      language: CSharp
      name:
        CSharp: GridCube
        VB: GridCube
      nameWithType:
        CSharp: SubTileMap.GridCube
        VB: SubTileMap.GridCube
      qualifiedName:
        CSharp: Tetris.SubTileMap.GridCube
        VB: Tetris.SubTileMap.GridCube
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: GridCube
        path: ''
        startLine: 2207
      syntax:
        content:
          CSharp: public GameObject[, ] GridCube { get; set; }
          VB: Public Property GridCube As GameObject(,)
        parameters: []
        return:
          type: GameObject[,]
      overload: Tetris.SubTileMap.GridCube*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
  - id: Tetris.Tetromino
    commentId: T:Tetris.Tetromino
    language: CSharp
    name:
      CSharp: Tetromino
      VB: Tetromino
    nameWithType:
      CSharp: Tetromino
      VB: Tetromino
    qualifiedName:
      CSharp: Tetris.Tetromino
      VB: Tetris.Tetromino
    type: Class
    assemblies:
    - cs.temp.dll
    namespace: Tetris
    source:
      id: Tetromino
      path: ''
      startLine: 2214
    syntax:
      content:
        CSharp: public class Tetromino
        VB: Public Class Tetromino
    inheritance:
    - System.Object
    modifiers:
      CSharp:
      - public
      - class
      VB:
      - Public
      - Class
    items:
    - id: Tetris.Tetromino.Id
      commentId: F:Tetris.Tetromino.Id
      language: CSharp
      name:
        CSharp: Id
        VB: Id
      nameWithType:
        CSharp: Tetromino.Id
        VB: Tetromino.Id
      qualifiedName:
        CSharp: Tetris.Tetromino.Id
        VB: Tetris.Tetromino.Id
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Id
        path: ''
        startLine: 2218
      syntax:
        content:
          CSharp: public int Id
          VB: Public Id As Integer
        return:
          type: System.Int32
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.Tetromino.Location
      commentId: P:Tetris.Tetromino.Location
      language: CSharp
      name:
        CSharp: Location
        VB: Location
      nameWithType:
        CSharp: Tetromino.Location
        VB: Tetromino.Location
      qualifiedName:
        CSharp: Tetris.Tetromino.Location
        VB: Tetris.Tetromino.Location
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Location
        path: ''
        startLine: 2219
      syntax:
        content:
          CSharp: public float[] Location { get; set; }
          VB: Public Property Location As Single()
        parameters: []
        return:
          type: System.Single[]
      overload: Tetris.Tetromino.Location*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Tetromino.RGrid
      commentId: P:Tetris.Tetromino.RGrid
      language: CSharp
      name:
        CSharp: RGrid
        VB: RGrid
      nameWithType:
        CSharp: Tetromino.RGrid
        VB: Tetromino.RGrid
      qualifiedName:
        CSharp: Tetris.Tetromino.RGrid
        VB: Tetris.Tetromino.RGrid
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: RGrid
        path: ''
        startLine: 2222
      syntax:
        content:
          CSharp: public int[, ] RGrid { get; set; }
          VB: Public Property RGrid As Integer(,)
        parameters: []
        return:
          type: System.Int32[,]
      overload: Tetris.Tetromino.RGrid*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Tetromino.Size
      commentId: P:Tetris.Tetromino.Size
      language: CSharp
      name:
        CSharp: Size
        VB: Size
      nameWithType:
        CSharp: Tetromino.Size
        VB: Tetromino.Size
      qualifiedName:
        CSharp: Tetris.Tetromino.Size
        VB: Tetris.Tetromino.Size
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Size
        path: ''
        startLine: 2223
      syntax:
        content:
          CSharp: public int Size { get; set; }
          VB: Public Property Size As Integer
        parameters: []
        return:
          type: System.Int32
      overload: Tetris.Tetromino.Size*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Tetromino.Type
      commentId: P:Tetris.Tetromino.Type
      language: CSharp
      name:
        CSharp: Type
        VB: Type
      nameWithType:
        CSharp: Tetromino.Type
        VB: Tetromino.Type
      qualifiedName:
        CSharp: Tetris.Tetromino.Type
        VB: Tetris.Tetromino.Type
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Type
        path: ''
        startLine: 2224
      syntax:
        content:
          CSharp: public string Type { get; set; }
          VB: Public Property Type As String
        parameters: []
        return:
          type: System.String
      overload: Tetris.Tetromino.Type*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Tetromino.CubeGo
      commentId: P:Tetris.Tetromino.CubeGo
      language: CSharp
      name:
        CSharp: CubeGo
        VB: CubeGo
      nameWithType:
        CSharp: Tetromino.CubeGo
        VB: Tetromino.CubeGo
      qualifiedName:
        CSharp: Tetris.Tetromino.CubeGo
        VB: Tetris.Tetromino.CubeGo
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: CubeGo
        path: ''
        startLine: 2225
      syntax:
        content:
          CSharp: public GameObject[, ] CubeGo { get; set; }
          VB: Public Property CubeGo As GameObject(,)
        parameters: []
        return:
          type: GameObject[,]
      overload: Tetris.Tetromino.CubeGo*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Tetromino.IsActive
      commentId: P:Tetris.Tetromino.IsActive
      language: CSharp
      name:
        CSharp: IsActive
        VB: IsActive
      nameWithType:
        CSharp: Tetromino.IsActive
        VB: Tetromino.IsActive
      qualifiedName:
        CSharp: Tetris.Tetromino.IsActive
        VB: Tetris.Tetromino.IsActive
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsActive
        path: ''
        startLine: 2226
      syntax:
        content:
          CSharp: public bool IsActive { get; set; }
          VB: Public Property IsActive As Boolean
        parameters: []
        return:
          type: System.Boolean
      overload: Tetris.Tetromino.IsActive*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Tetromino.IsHold
      commentId: P:Tetris.Tetromino.IsHold
      language: CSharp
      name:
        CSharp: IsHold
        VB: IsHold
      nameWithType:
        CSharp: Tetromino.IsHold
        VB: Tetromino.IsHold
      qualifiedName:
        CSharp: Tetris.Tetromino.IsHold
        VB: Tetris.Tetromino.IsHold
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsHold
        path: ''
        startLine: 2227
      syntax:
        content:
          CSharp: public bool IsHold { get; set; }
          VB: Public Property IsHold As Boolean
        parameters: []
        return:
          type: System.Boolean
      overload: Tetris.Tetromino.IsHold*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Tetromino.IsLocked
      commentId: P:Tetris.Tetromino.IsLocked
      language: CSharp
      name:
        CSharp: IsLocked
        VB: IsLocked
      nameWithType:
        CSharp: Tetromino.IsLocked
        VB: Tetromino.IsLocked
      qualifiedName:
        CSharp: Tetris.Tetromino.IsLocked
        VB: Tetris.Tetromino.IsLocked
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsLocked
        path: ''
        startLine: 2228
      syntax:
        content:
          CSharp: public bool IsLocked { get; set; }
          VB: Public Property IsLocked As Boolean
        parameters: []
        return:
          type: System.Boolean
      overload: Tetris.Tetromino.IsLocked*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Tetromino.AtSpawn
      commentId: P:Tetris.Tetromino.AtSpawn
      language: CSharp
      name:
        CSharp: AtSpawn
        VB: AtSpawn
      nameWithType:
        CSharp: Tetromino.AtSpawn
        VB: Tetromino.AtSpawn
      qualifiedName:
        CSharp: Tetris.Tetromino.AtSpawn
        VB: Tetris.Tetromino.AtSpawn
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: AtSpawn
        path: ''
        startLine: 2229
      syntax:
        content:
          CSharp: public bool AtSpawn { get; set; }
          VB: Public Property AtSpawn As Boolean
        parameters: []
        return:
          type: System.Boolean
      overload: Tetris.Tetromino.AtSpawn*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Tetromino.TetrominoGo
      commentId: P:Tetris.Tetromino.TetrominoGo
      language: CSharp
      name:
        CSharp: TetrominoGo
        VB: TetrominoGo
      nameWithType:
        CSharp: Tetromino.TetrominoGo
        VB: Tetromino.TetrominoGo
      qualifiedName:
        CSharp: Tetris.Tetromino.TetrominoGo
        VB: Tetris.Tetromino.TetrominoGo
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: TetrominoGo
        path: ''
        startLine: 2230
      syntax:
        content:
          CSharp: public GameObject TetrominoGo { get; set; }
          VB: Public Property TetrominoGo As GameObject
        parameters: []
        return:
          type: GameObject
      overload: Tetris.Tetromino.TetrominoGo*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Tetromino.RotationState
      commentId: P:Tetris.Tetromino.RotationState
      language: CSharp
      name:
        CSharp: RotationState
        VB: RotationState
      nameWithType:
        CSharp: Tetromino.RotationState
        VB: Tetromino.RotationState
      qualifiedName:
        CSharp: Tetris.Tetromino.RotationState
        VB: Tetris.Tetromino.RotationState
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: RotationState
        path: ''
        startLine: 2231
      syntax:
        content:
          CSharp: public int RotationState { get; set; }
          VB: Public Property RotationState As Integer
        parameters: []
        return:
          type: System.Int32
      overload: Tetris.Tetromino.RotationState*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
    - id: Tetris.Tetromino.Color
      commentId: P:Tetris.Tetromino.Color
      language: CSharp
      name:
        CSharp: Color
        VB: Color
      nameWithType:
        CSharp: Tetromino.Color
        VB: Tetromino.Color
      qualifiedName:
        CSharp: Tetris.Tetromino.Color
        VB: Tetris.Tetromino.Color
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: Color
        path: ''
        startLine: 2232
      syntax:
        content:
          CSharp: public Color Color { get; set; }
          VB: Public Property Color As Color
        parameters: []
        return:
          type: Color
      overload: Tetris.Tetromino.Color*
      modifiers:
        CSharp:
        - public
        - get
        - set
        VB:
        - Public
  - id: Tetris.TileMap
    commentId: T:Tetris.TileMap
    language: CSharp
    name:
      CSharp: TileMap
      VB: TileMap
    nameWithType:
      CSharp: TileMap
      VB: TileMap
    qualifiedName:
      CSharp: Tetris.TileMap
      VB: Tetris.TileMap
    type: Class
    assemblies:
    - cs.temp.dll
    namespace: Tetris
    source:
      id: TileMap
      path: ''
      startLine: 2243
    syntax:
      content:
        CSharp: 'public class TileMap : MonoBehaviour'
        VB: >-
          Public Class TileMap

              Inherits MonoBehaviour
    inheritance:
    - System.Object
    modifiers:
      CSharp:
      - public
      - class
      VB:
      - Public
      - Class
    items:
    - id: Tetris.TileMap.GridHeight
      commentId: F:Tetris.TileMap.GridHeight
      language: CSharp
      name:
        CSharp: GridHeight
        VB: GridHeight
      nameWithType:
        CSharp: TileMap.GridHeight
        VB: TileMap.GridHeight
      qualifiedName:
        CSharp: Tetris.TileMap.GridHeight
        VB: Tetris.TileMap.GridHeight
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: GridHeight
        path: ''
        startLine: 2246
      syntax:
        content:
          CSharp: public static int GridHeight
          VB: Public Shared GridHeight As Integer
        return:
          type: System.Int32
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.TileMap.GridWidth
      commentId: F:Tetris.TileMap.GridWidth
      language: CSharp
      name:
        CSharp: GridWidth
        VB: GridWidth
      nameWithType:
        CSharp: TileMap.GridWidth
        VB: TileMap.GridWidth
      qualifiedName:
        CSharp: Tetris.TileMap.GridWidth
        VB: Tetris.TileMap.GridWidth
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: GridWidth
        path: ''
        startLine: 2247
      syntax:
        content:
          CSharp: public static int GridWidth
          VB: Public Shared GridWidth As Integer
        return:
          type: System.Int32
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.TileMap.IsGameOver
      commentId: F:Tetris.TileMap.IsGameOver
      language: CSharp
      name:
        CSharp: IsGameOver
        VB: IsGameOver
      nameWithType:
        CSharp: TileMap.IsGameOver
        VB: TileMap.IsGameOver
      qualifiedName:
        CSharp: Tetris.TileMap.IsGameOver
        VB: Tetris.TileMap.IsGameOver
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsGameOver
        path: ''
        startLine: 2248
      syntax:
        content:
          CSharp: public static bool IsGameOver
          VB: Public Shared IsGameOver As Boolean
        return:
          type: System.Boolean
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.TileMap.IsClear
      commentId: F:Tetris.TileMap.IsClear
      language: CSharp
      name:
        CSharp: IsClear
        VB: IsClear
      nameWithType:
        CSharp: TileMap.IsClear
        VB: TileMap.IsClear
      qualifiedName:
        CSharp: Tetris.TileMap.IsClear
        VB: Tetris.TileMap.IsClear
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: IsClear
        path: ''
        startLine: 2252
      syntax:
        content:
          CSharp: public static List<int> IsClear
          VB: Public Shared IsClear As List(Of Integer)
        return:
          type: System.Collections.Generic.List{System.Int32}
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
    - id: Tetris.TileMap.blockPrefab
      commentId: F:Tetris.TileMap.blockPrefab
      language: CSharp
      name:
        CSharp: blockPrefab
        VB: blockPrefab
      nameWithType:
        CSharp: TileMap.blockPrefab
        VB: TileMap.blockPrefab
      qualifiedName:
        CSharp: Tetris.TileMap.blockPrefab
        VB: Tetris.TileMap.blockPrefab
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: blockPrefab
        path: ''
        startLine: 2255
      syntax:
        content:
          CSharp: public GameObject blockPrefab
          VB: Public blockPrefab As GameObject
        return:
          type: GameObject
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.TileMap.timeGameOver
      commentId: F:Tetris.TileMap.timeGameOver
      language: CSharp
      name:
        CSharp: timeGameOver
        VB: timeGameOver
      nameWithType:
        CSharp: TileMap.timeGameOver
        VB: TileMap.timeGameOver
      qualifiedName:
        CSharp: Tetris.TileMap.timeGameOver
        VB: Tetris.TileMap.timeGameOver
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: timeGameOver
        path: ''
        startLine: 2258
      syntax:
        content:
          CSharp: public float timeGameOver
          VB: Public timeGameOver As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.TileMap.timeToGameOver
      commentId: F:Tetris.TileMap.timeToGameOver
      language: CSharp
      name:
        CSharp: timeToGameOver
        VB: timeToGameOver
      nameWithType:
        CSharp: TileMap.timeToGameOver
        VB: TileMap.timeToGameOver
      qualifiedName:
        CSharp: Tetris.TileMap.timeToGameOver
        VB: Tetris.TileMap.timeToGameOver
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: timeToGameOver
        path: ''
        startLine: 2259
      syntax:
        content:
          CSharp: public float timeToGameOver
          VB: Public timeToGameOver As Single
        return:
          type: System.Single
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.TileMap.blockWithTexture
      commentId: F:Tetris.TileMap.blockWithTexture
      language: CSharp
      name:
        CSharp: blockWithTexture
        VB: blockWithTexture
      nameWithType:
        CSharp: TileMap.blockWithTexture
        VB: TileMap.blockWithTexture
      qualifiedName:
        CSharp: Tetris.TileMap.blockWithTexture
        VB: Tetris.TileMap.blockWithTexture
      type: Field
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: blockWithTexture
        path: ''
        startLine: 2261
      syntax:
        content:
          CSharp: public Material blockWithTexture
          VB: Public blockWithTexture As Material
        return:
          type: Material
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.TileMap.LineToAnimate
      commentId: P:Tetris.TileMap.LineToAnimate
      language: CSharp
      name:
        CSharp: LineToAnimate
        VB: LineToAnimate
      nameWithType:
        CSharp: TileMap.LineToAnimate
        VB: TileMap.LineToAnimate
      qualifiedName:
        CSharp: Tetris.TileMap.LineToAnimate
        VB: Tetris.TileMap.LineToAnimate
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: LineToAnimate
        path: ''
        startLine: 2263
      syntax:
        content:
          CSharp: public static GameObject[, ] LineToAnimate { get; set; }
          VB: Public Shared Property LineToAnimate As GameObject(,)
        parameters: []
        return:
          type: GameObject[,]
      overload: Tetris.TileMap.LineToAnimate*
      modifiers:
        CSharp:
        - public
        - static
        - get
        - set
        VB:
        - Public
        - Shared
    - id: Tetris.TileMap.GameOverCube
      commentId: P:Tetris.TileMap.GameOverCube
      language: CSharp
      name:
        CSharp: GameOverCube
        VB: GameOverCube
      nameWithType:
        CSharp: TileMap.GameOverCube
        VB: TileMap.GameOverCube
      qualifiedName:
        CSharp: Tetris.TileMap.GameOverCube
        VB: Tetris.TileMap.GameOverCube
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: GameOverCube
        path: ''
        startLine: 2264
      syntax:
        content:
          CSharp: public static GameObject[, ] GameOverCube { get; set; }
          VB: Public Shared Property GameOverCube As GameObject(,)
        parameters: []
        return:
          type: GameObject[,]
      overload: Tetris.TileMap.GameOverCube*
      modifiers:
        CSharp:
        - public
        - static
        - get
        - set
        VB:
        - Public
        - Shared
    - id: Tetris.TileMap.PlayGrid
      commentId: P:Tetris.TileMap.PlayGrid
      language: CSharp
      name:
        CSharp: PlayGrid
        VB: PlayGrid
      nameWithType:
        CSharp: TileMap.PlayGrid
        VB: TileMap.PlayGrid
      qualifiedName:
        CSharp: Tetris.TileMap.PlayGrid
        VB: Tetris.TileMap.PlayGrid
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: PlayGrid
        path: ''
        startLine: 2266
      syntax:
        content:
          CSharp: public static int[, ] PlayGrid { get; set; }
          VB: Public Shared Property PlayGrid As Integer(,)
        parameters: []
        return:
          type: System.Int32[,]
      overload: Tetris.TileMap.PlayGrid*
      modifiers:
        CSharp:
        - public
        - static
        - get
        - set
        VB:
        - Public
        - Shared
    - id: Tetris.TileMap.MovementTileMap
      commentId: P:Tetris.TileMap.MovementTileMap
      language: CSharp
      name:
        CSharp: MovementTileMap
        VB: MovementTileMap
      nameWithType:
        CSharp: TileMap.MovementTileMap
        VB: TileMap.MovementTileMap
      qualifiedName:
        CSharp: Tetris.TileMap.MovementTileMap
        VB: Tetris.TileMap.MovementTileMap
      type: Property
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: MovementTileMap
        path: ''
        startLine: 2267
      syntax:
        content:
          CSharp: public static SubTileMap MovementTileMap { get; set; }
          VB: Public Shared Property MovementTileMap As SubTileMap
        parameters: []
        return:
          type: Tetris.SubTileMap
      overload: Tetris.TileMap.MovementTileMap*
      modifiers:
        CSharp:
        - public
        - static
        - get
        - set
        VB:
        - Public
        - Shared
    - id: Tetris.TileMap.InitializeGrid
      commentId: M:Tetris.TileMap.InitializeGrid
      language: CSharp
      name:
        CSharp: InitializeGrid()
        VB: InitializeGrid()
      nameWithType:
        CSharp: TileMap.InitializeGrid()
        VB: TileMap.InitializeGrid()
      qualifiedName:
        CSharp: Tetris.TileMap.InitializeGrid()
        VB: Tetris.TileMap.InitializeGrid()
      type: Method
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: InitializeGrid
        path: ''
        startLine: 2285
      syntax:
        content:
          CSharp: public void InitializeGrid()
          VB: Public Sub InitializeGrid
      overload: Tetris.TileMap.InitializeGrid*
      modifiers:
        CSharp:
        - public
        VB:
        - Public
    - id: Tetris.TileMap.GameOver(System.Boolean)
      commentId: M:Tetris.TileMap.GameOver(System.Boolean)
      language: CSharp
      name:
        CSharp: GameOver(Boolean)
        VB: GameOver(Boolean)
      nameWithType:
        CSharp: TileMap.GameOver(Boolean)
        VB: TileMap.GameOver(Boolean)
      qualifiedName:
        CSharp: Tetris.TileMap.GameOver(System.Boolean)
        VB: Tetris.TileMap.GameOver(System.Boolean)
      type: Method
      assemblies:
      - cs.temp.dll
      namespace: Tetris
      source:
        id: GameOver
        path: ''
        startLine: 2323
      syntax:
        content:
          CSharp: public static void GameOver(bool isReal)
          VB: Public Shared Sub GameOver(isReal As Boolean)
        parameters:
        - id: isReal
          type: System.Boolean
      overload: Tetris.TileMap.GameOver*
      modifiers:
        CSharp:
        - public
        - static
        VB:
        - Public
        - Shared
references:
  System.Collections.Generic.List`1:
    name:
      CSharp:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: <
        nameWithType: <
        qualifiedName: <
      - name: T
        nameWithType: T
        qualifiedName: T
      - name: '>'
        nameWithType: '>'
        qualifiedName: '>'
      VB:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: '(Of '
        nameWithType: '(Of '
        qualifiedName: '(Of '
      - name: T
        nameWithType: T
        qualifiedName: T
      - name: )
        nameWithType: )
        qualifiedName: )
    isDefinition: true
    commentId: T:System.Collections.Generic.List`1
  System.Collections.Generic:
    name:
      CSharp:
      - name: System.Collections.Generic
        nameWithType: System.Collections.Generic
        qualifiedName: System.Collections.Generic
        isExternal: true
      VB:
      - name: System.Collections.Generic
        nameWithType: System.Collections.Generic
        qualifiedName: System.Collections.Generic
    isDefinition: true
    commentId: N:System.Collections.Generic
  System.Collections.Generic.List{System.Boolean}:
    name:
      CSharp:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: <
        nameWithType: <
        qualifiedName: <
      - id: System.Boolean
        name: Boolean
        nameWithType: Boolean
        qualifiedName: System.Boolean
        isExternal: true
      - name: '>'
        nameWithType: '>'
        qualifiedName: '>'
      VB:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: '(Of '
        nameWithType: '(Of '
        qualifiedName: '(Of '
      - id: System.Boolean
        name: Boolean
        nameWithType: Boolean
        qualifiedName: System.Boolean
        isExternal: true
      - name: )
        nameWithType: )
        qualifiedName: )
    isDefinition: false
    definition: System.Collections.Generic.List`1
    parent: System.Collections.Generic
    commentId: T:System.Collections.Generic.List{System.Boolean}
  GameObject:
    name:
      CSharp:
      - id: GameObject
        name: GameObject
        nameWithType: GameObject
        qualifiedName: GameObject
        isExternal: true
      VB:
      - id: GameObject
        name: GameObject
        nameWithType: GameObject
        qualifiedName: GameObject
        isExternal: true
    isDefinition: true
  System.String[]:
    name:
      CSharp:
      - id: System.String
        name: String
        nameWithType: String
        qualifiedName: System.String
        isExternal: true
      - name: '[]'
        nameWithType: '[]'
        qualifiedName: '[]'
      VB:
      - id: System.String
        name: String
        nameWithType: String
        qualifiedName: System.String
        isExternal: true
      - name: ()
        nameWithType: ()
        qualifiedName: ()
    isDefinition: false
  System.Collections.Generic.List{System.Single}:
    name:
      CSharp:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: <
        nameWithType: <
        qualifiedName: <
      - id: System.Single
        name: Single
        nameWithType: Single
        qualifiedName: System.Single
        isExternal: true
      - name: '>'
        nameWithType: '>'
        qualifiedName: '>'
      VB:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: '(Of '
        nameWithType: '(Of '
        qualifiedName: '(Of '
      - id: System.Single
        name: Single
        nameWithType: Single
        qualifiedName: System.Single
        isExternal: true
      - name: )
        nameWithType: )
        qualifiedName: )
    isDefinition: false
    definition: System.Collections.Generic.List`1
    parent: System.Collections.Generic
    commentId: T:System.Collections.Generic.List{System.Single}
  System:
    name:
      CSharp:
      - name: System
        nameWithType: System
        qualifiedName: System
        isExternal: true
      VB:
      - name: System
        nameWithType: System
        qualifiedName: System
    isDefinition: true
    commentId: N:System
  System.Single:
    name:
      CSharp:
      - id: System.Single
        name: Single
        nameWithType: Single
        qualifiedName: System.Single
        isExternal: true
      VB:
      - id: System.Single
        name: Single
        nameWithType: Single
        qualifiedName: System.Single
        isExternal: true
    isDefinition: true
    parent: System
    commentId: T:System.Single
  System.Collections.Generic.List{System.Int32}:
    name:
      CSharp:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: <
        nameWithType: <
        qualifiedName: <
      - id: System.Int32
        name: Int32
        nameWithType: Int32
        qualifiedName: System.Int32
        isExternal: true
      - name: '>'
        nameWithType: '>'
        qualifiedName: '>'
      VB:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: '(Of '
        nameWithType: '(Of '
        qualifiedName: '(Of '
      - id: System.Int32
        name: Int32
        nameWithType: Int32
        qualifiedName: System.Int32
        isExternal: true
      - name: )
        nameWithType: )
        qualifiedName: )
    isDefinition: false
    definition: System.Collections.Generic.List`1
    parent: System.Collections.Generic
    commentId: T:System.Collections.Generic.List{System.Int32}
  System.Boolean:
    name:
      CSharp:
      - id: System.Boolean
        name: Boolean
        nameWithType: Boolean
        qualifiedName: System.Boolean
        isExternal: true
      VB:
      - id: System.Boolean
        name: Boolean
        nameWithType: Boolean
        qualifiedName: System.Boolean
        isExternal: true
    isDefinition: true
    parent: System
    commentId: T:System.Boolean
  System.Collections.Generic.List{GameObject}:
    name:
      CSharp:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: <
        nameWithType: <
        qualifiedName: <
      - id: GameObject
        name: GameObject
        nameWithType: GameObject
        qualifiedName: GameObject
        isExternal: true
      - name: '>'
        nameWithType: '>'
        qualifiedName: '>'
      VB:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: '(Of '
        nameWithType: '(Of '
        qualifiedName: '(Of '
      - id: GameObject
        name: GameObject
        nameWithType: GameObject
        qualifiedName: GameObject
        isExternal: true
      - name: )
        nameWithType: )
        qualifiedName: )
    isDefinition: false
    definition: System.Collections.Generic.List`1
    parent: System.Collections.Generic
    commentId: T:System.Collections.Generic.List{GameObject}
  System.Int32:
    name:
      CSharp:
      - id: System.Int32
        name: Int32
        nameWithType: Int32
        qualifiedName: System.Int32
        isExternal: true
      VB:
      - id: System.Int32
        name: Int32
        nameWithType: Int32
        qualifiedName: System.Int32
        isExternal: true
    isDefinition: true
    parent: System
    commentId: T:System.Int32
  Vector3:
    name:
      CSharp:
      - id: Vector3
        name: Vector3
        nameWithType: Vector3
        qualifiedName: Vector3
        isExternal: true
      VB:
      - id: Vector3
        name: Vector3
        nameWithType: Vector3
        qualifiedName: Vector3
        isExternal: true
    isDefinition: true
    commentId: '!:Vector3'
  System.Collections.Generic.List{Vector3}:
    name:
      CSharp:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: <
        nameWithType: <
        qualifiedName: <
      - id: Vector3
        name: Vector3
        nameWithType: Vector3
        qualifiedName: Vector3
        isExternal: true
      - name: '>'
        nameWithType: '>'
        qualifiedName: '>'
      VB:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: '(Of '
        nameWithType: '(Of '
        qualifiedName: '(Of '
      - id: Vector3
        name: Vector3
        nameWithType: Vector3
        qualifiedName: Vector3
        isExternal: true
      - name: )
        nameWithType: )
        qualifiedName: )
    isDefinition: false
    definition: System.Collections.Generic.List`1
    parent: System.Collections.Generic
    commentId: T:System.Collections.Generic.List{Vector3}
  System.Collections.Generic.List{Tetris.Tetromino}:
    name:
      CSharp:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: <
        nameWithType: <
        qualifiedName: <
      - id: Tetris.Tetromino
        name: Tetromino
        nameWithType: Tetromino
        qualifiedName: Tetris.Tetromino
      - name: '>'
        nameWithType: '>'
        qualifiedName: '>'
      VB:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: '(Of '
        nameWithType: '(Of '
        qualifiedName: '(Of '
      - id: Tetris.Tetromino
        name: Tetromino
        nameWithType: Tetromino
        qualifiedName: Tetris.Tetromino
      - name: )
        nameWithType: )
        qualifiedName: )
    isDefinition: false
    definition: System.Collections.Generic.List`1
    parent: System.Collections.Generic
    commentId: T:System.Collections.Generic.List{Tetris.Tetromino}
  Material:
    name:
      CSharp:
      - id: Material
        name: Material
        nameWithType: Material
        qualifiedName: Material
        isExternal: true
      VB:
      - id: Material
        name: Material
        nameWithType: Material
        qualifiedName: Material
        isExternal: true
    isDefinition: true
  Tetris.Blocks.InitializePlayer*:
    name:
      CSharp:
      - id: Tetris.Blocks.InitializePlayer*
        name: InitializePlayer
        nameWithType: Blocks.InitializePlayer
        qualifiedName: Tetris.Blocks.InitializePlayer
      VB:
      - id: Tetris.Blocks.InitializePlayer*
        name: InitializePlayer
        nameWithType: Blocks.InitializePlayer
        qualifiedName: Tetris.Blocks.InitializePlayer
    isDefinition: true
    commentId: Overload:Tetris.Blocks.InitializePlayer
  Tetris.Blocks.RemovePlayer*:
    name:
      CSharp:
      - id: Tetris.Blocks.RemovePlayer*
        name: RemovePlayer
        nameWithType: Blocks.RemovePlayer
        qualifiedName: Tetris.Blocks.RemovePlayer
      VB:
      - id: Tetris.Blocks.RemovePlayer*
        name: RemovePlayer
        nameWithType: Blocks.RemovePlayer
        qualifiedName: Tetris.Blocks.RemovePlayer
    isDefinition: true
    commentId: Overload:Tetris.Blocks.RemovePlayer
  System.String:
    name:
      CSharp:
      - id: System.String
        name: String
        nameWithType: String
        qualifiedName: System.String
        isExternal: true
      VB:
      - id: System.String
        name: String
        nameWithType: String
        qualifiedName: System.String
        isExternal: true
    isDefinition: true
    parent: System
    commentId: T:System.String
  Tetris.Blocks.SpawnMino*:
    name:
      CSharp:
      - id: Tetris.Blocks.SpawnMino*
        name: SpawnMino
        nameWithType: Blocks.SpawnMino
        qualifiedName: Tetris.Blocks.SpawnMino
      VB:
      - id: Tetris.Blocks.SpawnMino*
        name: SpawnMino
        nameWithType: Blocks.SpawnMino
        qualifiedName: Tetris.Blocks.SpawnMino
    isDefinition: true
    commentId: Overload:Tetris.Blocks.SpawnMino
  Tetris.Blocks:
    name:
      CSharp:
      - id: Tetris.Blocks
        name: Blocks
        nameWithType: Blocks
        qualifiedName: Tetris.Blocks
      VB:
      - id: Tetris.Blocks
        name: Blocks
        nameWithType: Blocks
        qualifiedName: Tetris.Blocks
    isDefinition: true
    commentId: T:Tetris.Blocks
  Tetris.SubMenu[]:
    name:
      CSharp:
      - id: Tetris.SubMenu
        name: SubMenu
        nameWithType: SubMenu
        qualifiedName: Tetris.SubMenu
      - name: '[]'
        nameWithType: '[]'
        qualifiedName: '[]'
      VB:
      - id: Tetris.SubMenu
        name: SubMenu
        nameWithType: SubMenu
        qualifiedName: Tetris.SubMenu
      - name: ()
        nameWithType: ()
        qualifiedName: ()
    isDefinition: false
  Tetris.Menu.Menus*:
    name:
      CSharp:
      - id: Tetris.Menu.Menus*
        name: Menus
        nameWithType: Menu.Menus
        qualifiedName: Tetris.Menu.Menus
      VB:
      - id: Tetris.Menu.Menus*
        name: Menus
        nameWithType: Menu.Menus
        qualifiedName: Tetris.Menu.Menus
    isDefinition: true
    commentId: Overload:Tetris.Menu.Menus
  Tetris.Menu.PlayerCount*:
    name:
      CSharp:
      - id: Tetris.Menu.PlayerCount*
        name: PlayerCount
        nameWithType: Menu.PlayerCount
        qualifiedName: Tetris.Menu.PlayerCount
      VB:
      - id: Tetris.Menu.PlayerCount*
        name: PlayerCount
        nameWithType: Menu.PlayerCount
        qualifiedName: Tetris.Menu.PlayerCount
    isDefinition: true
    commentId: Overload:Tetris.Menu.PlayerCount
  Tetris.Menu.NeedToAddPlayer*:
    name:
      CSharp:
      - id: Tetris.Menu.NeedToAddPlayer*
        name: NeedToAddPlayer
        nameWithType: Menu.NeedToAddPlayer
        qualifiedName: Tetris.Menu.NeedToAddPlayer
      VB:
      - id: Tetris.Menu.NeedToAddPlayer*
        name: NeedToAddPlayer
        nameWithType: Menu.NeedToAddPlayer
        qualifiedName: Tetris.Menu.NeedToAddPlayer
    isDefinition: true
    commentId: Overload:Tetris.Menu.NeedToAddPlayer
  Tetris.Menu.NeedToRemovePlayer*:
    name:
      CSharp:
      - id: Tetris.Menu.NeedToRemovePlayer*
        name: NeedToRemovePlayer
        nameWithType: Menu.NeedToRemovePlayer
        qualifiedName: Tetris.Menu.NeedToRemovePlayer
      VB:
      - id: Tetris.Menu.NeedToRemovePlayer*
        name: NeedToRemovePlayer
        nameWithType: Menu.NeedToRemovePlayer
        qualifiedName: Tetris.Menu.NeedToRemovePlayer
    isDefinition: true
    commentId: Overload:Tetris.Menu.NeedToRemovePlayer
  Tetris.Menu:
    name:
      CSharp:
      - id: Tetris.Menu
        name: Menu
        nameWithType: Menu
        qualifiedName: Tetris.Menu
      VB:
      - id: Tetris.Menu
        name: Menu
        nameWithType: Menu
        qualifiedName: Tetris.Menu
    isDefinition: true
    commentId: T:Tetris.Menu
  System.Collections.Generic.List{System.String}:
    name:
      CSharp:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: <
        nameWithType: <
        qualifiedName: <
      - id: System.String
        name: String
        nameWithType: String
        qualifiedName: System.String
        isExternal: true
      - name: '>'
        nameWithType: '>'
        qualifiedName: '>'
      VB:
      - id: System.Collections.Generic.List`1
        name: List
        nameWithType: List
        qualifiedName: System.Collections.Generic.List
        isExternal: true
      - name: '(Of '
        nameWithType: '(Of '
        qualifiedName: '(Of '
      - id: System.String
        name: String
        nameWithType: String
        qualifiedName: System.String
        isExternal: true
      - name: )
        nameWithType: )
        qualifiedName: )
    isDefinition: false
    definition: System.Collections.Generic.List`1
    parent: System.Collections.Generic
    commentId: T:System.Collections.Generic.List{System.String}
  System.Int32[,]:
    name:
      CSharp:
      - id: System.Int32
        name: Int32
        nameWithType: Int32
        qualifiedName: System.Int32
        isExternal: true
      - name: '[,]'
        nameWithType: '[,]'
        qualifiedName: '[,]'
      VB:
      - id: System.Int32
        name: Int32
        nameWithType: Int32
        qualifiedName: System.Int32
        isExternal: true
      - name: (,)
        nameWithType: (,)
        qualifiedName: (,)
    isDefinition: false
  Tetris.Rotation.RGridCache*:
    name:
      CSharp:
      - id: Tetris.Rotation.RGridCache*
        name: RGridCache
        nameWithType: Rotation.RGridCache
        qualifiedName: Tetris.Rotation.RGridCache
      VB:
      - id: Tetris.Rotation.RGridCache*
        name: RGridCache
        nameWithType: Rotation.RGridCache
        qualifiedName: Tetris.Rotation.RGridCache
    isDefinition: true
    commentId: Overload:Tetris.Rotation.RGridCache
  Tetris.Rotation.CanRotate*:
    name:
      CSharp:
      - id: Tetris.Rotation.CanRotate*
        name: CanRotate
        nameWithType: Rotation.CanRotate
        qualifiedName: Tetris.Rotation.CanRotate
      VB:
      - id: Tetris.Rotation.CanRotate*
        name: CanRotate
        nameWithType: Rotation.CanRotate
        qualifiedName: Tetris.Rotation.CanRotate
    isDefinition: true
    commentId: Overload:Tetris.Rotation.CanRotate
  Tetris.Rotation.Rotate*:
    name:
      CSharp:
      - id: Tetris.Rotation.Rotate*
        name: Rotate
        nameWithType: Rotation.Rotate
        qualifiedName: Tetris.Rotation.Rotate
      VB:
      - id: Tetris.Rotation.Rotate*
        name: Rotate
        nameWithType: Rotation.Rotate
        qualifiedName: Tetris.Rotation.Rotate
    isDefinition: true
    commentId: Overload:Tetris.Rotation.Rotate
  Tetris.Rotation:
    name:
      CSharp:
      - id: Tetris.Rotation
        name: Rotation
        nameWithType: Rotation
        qualifiedName: Tetris.Rotation
      VB:
      - id: Tetris.Rotation
        name: Rotation
        nameWithType: Rotation
        qualifiedName: Tetris.Rotation
    isDefinition: true
    commentId: T:Tetris.Rotation
  Text:
    name:
      CSharp:
      - id: Text
        name: Text
        nameWithType: Text
        qualifiedName: Text
        isExternal: true
      VB:
      - id: Text
        name: Text
        nameWithType: Text
        qualifiedName: Text
        isExternal: true
    isDefinition: true
  Tetris.Blocks.SpawnMino(System.Int32,System.String):
    commentId: M:Tetris.Blocks.SpawnMino(System.Int32,System.String)
  Tetris.ScoreSystem.ScoreCounter*:
    name:
      CSharp:
      - id: Tetris.ScoreSystem.ScoreCounter*
        name: ScoreCounter
        nameWithType: ScoreSystem.ScoreCounter
        qualifiedName: Tetris.ScoreSystem.ScoreCounter
      VB:
      - id: Tetris.ScoreSystem.ScoreCounter*
        name: ScoreCounter
        nameWithType: ScoreSystem.ScoreCounter
        qualifiedName: Tetris.ScoreSystem.ScoreCounter
    isDefinition: true
    commentId: Overload:Tetris.ScoreSystem.ScoreCounter
  Tetris.ScoreSystem:
    name:
      CSharp:
      - id: Tetris.ScoreSystem
        name: ScoreSystem
        nameWithType: ScoreSystem
        qualifiedName: Tetris.ScoreSystem
      VB:
      - id: Tetris.ScoreSystem
        name: ScoreSystem
        nameWithType: ScoreSystem
        qualifiedName: Tetris.ScoreSystem
    isDefinition: true
    commentId: T:Tetris.ScoreSystem
  System.Object:
    name:
      CSharp:
      - id: System.Object
        name: Object
        nameWithType: Object
        qualifiedName: System.Object
        isExternal: true
      VB:
      - id: System.Object
        name: Object
        nameWithType: Object
        qualifiedName: System.Object
        isExternal: true
    isDefinition: true
    parent: System
    commentId: T:System.Object
  Tetris.SubMenu.Canvas*:
    name:
      CSharp:
      - id: Tetris.SubMenu.Canvas*
        name: Canvas
        nameWithType: SubMenu.Canvas
        qualifiedName: Tetris.SubMenu.Canvas
      VB:
      - id: Tetris.SubMenu.Canvas*
        name: Canvas
        nameWithType: SubMenu.Canvas
        qualifiedName: Tetris.SubMenu.Canvas
    isDefinition: true
    commentId: Overload:Tetris.SubMenu.Canvas
  Canvas:
    name:
      CSharp:
      - id: Canvas
        name: Canvas
        nameWithType: Canvas
        qualifiedName: Canvas
        isExternal: true
      VB:
      - id: Canvas
        name: Canvas
        nameWithType: Canvas
        qualifiedName: Canvas
        isExternal: true
    isDefinition: true
    commentId: '!:Canvas'
  Tetris.SubMenu.CanvasCanvas*:
    name:
      CSharp:
      - id: Tetris.SubMenu.CanvasCanvas*
        name: CanvasCanvas
        nameWithType: SubMenu.CanvasCanvas
        qualifiedName: Tetris.SubMenu.CanvasCanvas
      VB:
      - id: Tetris.SubMenu.CanvasCanvas*
        name: CanvasCanvas
        nameWithType: SubMenu.CanvasCanvas
        qualifiedName: Tetris.SubMenu.CanvasCanvas
    isDefinition: true
    commentId: Overload:Tetris.SubMenu.CanvasCanvas
  Text[]:
    name:
      CSharp:
      - id: Text
        name: Text
        nameWithType: Text
        qualifiedName: Text
        isExternal: true
      - name: '[]'
        nameWithType: '[]'
        qualifiedName: '[]'
      VB:
      - id: Text
        name: Text
        nameWithType: Text
        qualifiedName: Text
        isExternal: true
      - name: ()
        nameWithType: ()
        qualifiedName: ()
    isDefinition: false
  Tetris.SubMenu.MenuItem*:
    name:
      CSharp:
      - id: Tetris.SubMenu.MenuItem*
        name: MenuItem
        nameWithType: SubMenu.MenuItem
        qualifiedName: Tetris.SubMenu.MenuItem
      VB:
      - id: Tetris.SubMenu.MenuItem*
        name: MenuItem
        nameWithType: SubMenu.MenuItem
        qualifiedName: Tetris.SubMenu.MenuItem
    isDefinition: true
    commentId: Overload:Tetris.SubMenu.MenuItem
  GameObject[]:
    name:
      CSharp:
      - id: GameObject
        name: GameObject
        nameWithType: GameObject
        qualifiedName: GameObject
        isExternal: true
      - name: '[]'
        nameWithType: '[]'
        qualifiedName: '[]'
      VB:
      - id: GameObject
        name: GameObject
        nameWithType: GameObject
        qualifiedName: GameObject
        isExternal: true
      - name: ()
        nameWithType: ()
        qualifiedName: ()
    isDefinition: false
  Tetris.SubMenu.Menu*:
    name:
      CSharp:
      - id: Tetris.SubMenu.Menu*
        name: Menu
        nameWithType: SubMenu.Menu
        qualifiedName: Tetris.SubMenu.Menu
      VB:
      - id: Tetris.SubMenu.Menu*
        name: Menu
        nameWithType: SubMenu.Menu
        qualifiedName: Tetris.SubMenu.Menu
    isDefinition: true
    commentId: Overload:Tetris.SubMenu.Menu
  Tetris.SubMenu.MenuItem:
    commentId: P:Tetris.SubMenu.MenuItem
  Tetris.SubMenu.SelectedIndex*:
    name:
      CSharp:
      - id: Tetris.SubMenu.SelectedIndex*
        name: SelectedIndex
        nameWithType: SubMenu.SelectedIndex
        qualifiedName: Tetris.SubMenu.SelectedIndex
      VB:
      - id: Tetris.SubMenu.SelectedIndex*
        name: SelectedIndex
        nameWithType: SubMenu.SelectedIndex
        qualifiedName: Tetris.SubMenu.SelectedIndex
    isDefinition: true
    commentId: Overload:Tetris.SubMenu.SelectedIndex
  Tetris.SubMenu.MenuItemSelected*:
    name:
      CSharp:
      - id: Tetris.SubMenu.MenuItemSelected*
        name: MenuItemSelected
        nameWithType: SubMenu.MenuItemSelected
        qualifiedName: Tetris.SubMenu.MenuItemSelected
      VB:
      - id: Tetris.SubMenu.MenuItemSelected*
        name: MenuItemSelected
        nameWithType: SubMenu.MenuItemSelected
        qualifiedName: Tetris.SubMenu.MenuItemSelected
    isDefinition: true
    commentId: Overload:Tetris.SubMenu.MenuItemSelected
  Tetris.SubMenu.MenuItemCount*:
    name:
      CSharp:
      - id: Tetris.SubMenu.MenuItemCount*
        name: MenuItemCount
        nameWithType: SubMenu.MenuItemCount
        qualifiedName: Tetris.SubMenu.MenuItemCount
      VB:
      - id: Tetris.SubMenu.MenuItemCount*
        name: MenuItemCount
        nameWithType: SubMenu.MenuItemCount
        qualifiedName: Tetris.SubMenu.MenuItemCount
    isDefinition: true
    commentId: Overload:Tetris.SubMenu.MenuItemCount
  Tetris.SubMenu.IsPaused*:
    name:
      CSharp:
      - id: Tetris.SubMenu.IsPaused*
        name: IsPaused
        nameWithType: SubMenu.IsPaused
        qualifiedName: Tetris.SubMenu.IsPaused
      VB:
      - id: Tetris.SubMenu.IsPaused*
        name: IsPaused
        nameWithType: SubMenu.IsPaused
        qualifiedName: Tetris.SubMenu.IsPaused
    isDefinition: true
    commentId: Overload:Tetris.SubMenu.IsPaused
  Tetris.SubMenu:
    name:
      CSharp:
      - id: Tetris.SubMenu
        name: SubMenu
        nameWithType: SubMenu
        qualifiedName: Tetris.SubMenu
      VB:
      - id: Tetris.SubMenu
        name: SubMenu
        nameWithType: SubMenu
        qualifiedName: Tetris.SubMenu
    isDefinition: true
    commentId: T:Tetris.SubMenu
  System.Boolean[,]:
    name:
      CSharp:
      - id: System.Boolean
        name: Boolean
        nameWithType: Boolean
        qualifiedName: System.Boolean
        isExternal: true
      - name: '[,]'
        nameWithType: '[,]'
        qualifiedName: '[,]'
      VB:
      - id: System.Boolean
        name: Boolean
        nameWithType: Boolean
        qualifiedName: System.Boolean
        isExternal: true
      - name: (,)
        nameWithType: (,)
        qualifiedName: (,)
    isDefinition: false
  Tetris.SubTileMap.IsActive*:
    name:
      CSharp:
      - id: Tetris.SubTileMap.IsActive*
        name: IsActive
        nameWithType: SubTileMap.IsActive
        qualifiedName: Tetris.SubTileMap.IsActive
      VB:
      - id: Tetris.SubTileMap.IsActive*
        name: IsActive
        nameWithType: SubTileMap.IsActive
        qualifiedName: Tetris.SubTileMap.IsActive
    isDefinition: true
    commentId: Overload:Tetris.SubTileMap.IsActive
  Color[,]:
    name:
      CSharp:
      - id: Color
        name: Color
        nameWithType: Color
        qualifiedName: Color
        isExternal: true
      - name: '[,]'
        nameWithType: '[,]'
        qualifiedName: '[,]'
      VB:
      - id: Color
        name: Color
        nameWithType: Color
        qualifiedName: Color
        isExternal: true
      - name: (,)
        nameWithType: (,)
        qualifiedName: (,)
    isDefinition: false
  Tetris.SubTileMap.Color*:
    name:
      CSharp:
      - id: Tetris.SubTileMap.Color*
        name: Color
        nameWithType: SubTileMap.Color
        qualifiedName: Tetris.SubTileMap.Color
      VB:
      - id: Tetris.SubTileMap.Color*
        name: Color
        nameWithType: SubTileMap.Color
        qualifiedName: Tetris.SubTileMap.Color
    isDefinition: true
    commentId: Overload:Tetris.SubTileMap.Color
  Tetris.SubTileMap.IsClear*:
    name:
      CSharp:
      - id: Tetris.SubTileMap.IsClear*
        name: IsClear
        nameWithType: SubTileMap.IsClear
        qualifiedName: Tetris.SubTileMap.IsClear
      VB:
      - id: Tetris.SubTileMap.IsClear*
        name: IsClear
        nameWithType: SubTileMap.IsClear
        qualifiedName: Tetris.SubTileMap.IsClear
    isDefinition: true
    commentId: Overload:Tetris.SubTileMap.IsClear
  Tetris.SubTileMap.CollisionMap*:
    name:
      CSharp:
      - id: Tetris.SubTileMap.CollisionMap*
        name: CollisionMap
        nameWithType: SubTileMap.CollisionMap
        qualifiedName: Tetris.SubTileMap.CollisionMap
      VB:
      - id: Tetris.SubTileMap.CollisionMap*
        name: CollisionMap
        nameWithType: SubTileMap.CollisionMap
        qualifiedName: Tetris.SubTileMap.CollisionMap
    isDefinition: true
    commentId: Overload:Tetris.SubTileMap.CollisionMap
  GameObject[,]:
    name:
      CSharp:
      - id: GameObject
        name: GameObject
        nameWithType: GameObject
        qualifiedName: GameObject
        isExternal: true
      - name: '[,]'
        nameWithType: '[,]'
        qualifiedName: '[,]'
      VB:
      - id: GameObject
        name: GameObject
        nameWithType: GameObject
        qualifiedName: GameObject
        isExternal: true
      - name: (,)
        nameWithType: (,)
        qualifiedName: (,)
    isDefinition: false
  Tetris.SubTileMap.GridCube*:
    name:
      CSharp:
      - id: Tetris.SubTileMap.GridCube*
        name: GridCube
        nameWithType: SubTileMap.GridCube
        qualifiedName: Tetris.SubTileMap.GridCube
      VB:
      - id: Tetris.SubTileMap.GridCube*
        name: GridCube
        nameWithType: SubTileMap.GridCube
        qualifiedName: Tetris.SubTileMap.GridCube
    isDefinition: true
    commentId: Overload:Tetris.SubTileMap.GridCube
  Tetris.SubTileMap:
    name:
      CSharp:
      - id: Tetris.SubTileMap
        name: SubTileMap
        nameWithType: SubTileMap
        qualifiedName: Tetris.SubTileMap
      VB:
      - id: Tetris.SubTileMap
        name: SubTileMap
        nameWithType: SubTileMap
        qualifiedName: Tetris.SubTileMap
    isDefinition: true
    parent: Tetris
    commentId: T:Tetris.SubTileMap
  System.Single[]:
    name:
      CSharp:
      - id: System.Single
        name: Single
        nameWithType: Single
        qualifiedName: System.Single
        isExternal: true
      - name: '[]'
        nameWithType: '[]'
        qualifiedName: '[]'
      VB:
      - id: System.Single
        name: Single
        nameWithType: Single
        qualifiedName: System.Single
        isExternal: true
      - name: ()
        nameWithType: ()
        qualifiedName: ()
    isDefinition: false
  Tetris.Tetromino.Location*:
    name:
      CSharp:
      - id: Tetris.Tetromino.Location*
        name: Location
        nameWithType: Tetromino.Location
        qualifiedName: Tetris.Tetromino.Location
      VB:
      - id: Tetris.Tetromino.Location*
        name: Location
        nameWithType: Tetromino.Location
        qualifiedName: Tetris.Tetromino.Location
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.Location
  Tetris.Tetromino.RGrid*:
    name:
      CSharp:
      - id: Tetris.Tetromino.RGrid*
        name: RGrid
        nameWithType: Tetromino.RGrid
        qualifiedName: Tetris.Tetromino.RGrid
      VB:
      - id: Tetris.Tetromino.RGrid*
        name: RGrid
        nameWithType: Tetromino.RGrid
        qualifiedName: Tetris.Tetromino.RGrid
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.RGrid
  Tetris.Tetromino.Size*:
    name:
      CSharp:
      - id: Tetris.Tetromino.Size*
        name: Size
        nameWithType: Tetromino.Size
        qualifiedName: Tetris.Tetromino.Size
      VB:
      - id: Tetris.Tetromino.Size*
        name: Size
        nameWithType: Tetromino.Size
        qualifiedName: Tetris.Tetromino.Size
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.Size
  Tetris.Tetromino.Type*:
    name:
      CSharp:
      - id: Tetris.Tetromino.Type*
        name: Type
        nameWithType: Tetromino.Type
        qualifiedName: Tetris.Tetromino.Type
      VB:
      - id: Tetris.Tetromino.Type*
        name: Type
        nameWithType: Tetromino.Type
        qualifiedName: Tetris.Tetromino.Type
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.Type
  Tetris.Tetromino.CubeGo*:
    name:
      CSharp:
      - id: Tetris.Tetromino.CubeGo*
        name: CubeGo
        nameWithType: Tetromino.CubeGo
        qualifiedName: Tetris.Tetromino.CubeGo
      VB:
      - id: Tetris.Tetromino.CubeGo*
        name: CubeGo
        nameWithType: Tetromino.CubeGo
        qualifiedName: Tetris.Tetromino.CubeGo
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.CubeGo
  Tetris.Tetromino.IsActive*:
    name:
      CSharp:
      - id: Tetris.Tetromino.IsActive*
        name: IsActive
        nameWithType: Tetromino.IsActive
        qualifiedName: Tetris.Tetromino.IsActive
      VB:
      - id: Tetris.Tetromino.IsActive*
        name: IsActive
        nameWithType: Tetromino.IsActive
        qualifiedName: Tetris.Tetromino.IsActive
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.IsActive
  Tetris.Tetromino.IsHold*:
    name:
      CSharp:
      - id: Tetris.Tetromino.IsHold*
        name: IsHold
        nameWithType: Tetromino.IsHold
        qualifiedName: Tetris.Tetromino.IsHold
      VB:
      - id: Tetris.Tetromino.IsHold*
        name: IsHold
        nameWithType: Tetromino.IsHold
        qualifiedName: Tetris.Tetromino.IsHold
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.IsHold
  Tetris.Tetromino.IsLocked*:
    name:
      CSharp:
      - id: Tetris.Tetromino.IsLocked*
        name: IsLocked
        nameWithType: Tetromino.IsLocked
        qualifiedName: Tetris.Tetromino.IsLocked
      VB:
      - id: Tetris.Tetromino.IsLocked*
        name: IsLocked
        nameWithType: Tetromino.IsLocked
        qualifiedName: Tetris.Tetromino.IsLocked
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.IsLocked
  Tetris.Tetromino.AtSpawn*:
    name:
      CSharp:
      - id: Tetris.Tetromino.AtSpawn*
        name: AtSpawn
        nameWithType: Tetromino.AtSpawn
        qualifiedName: Tetris.Tetromino.AtSpawn
      VB:
      - id: Tetris.Tetromino.AtSpawn*
        name: AtSpawn
        nameWithType: Tetromino.AtSpawn
        qualifiedName: Tetris.Tetromino.AtSpawn
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.AtSpawn
  Tetris.Tetromino.TetrominoGo*:
    name:
      CSharp:
      - id: Tetris.Tetromino.TetrominoGo*
        name: TetrominoGo
        nameWithType: Tetromino.TetrominoGo
        qualifiedName: Tetris.Tetromino.TetrominoGo
      VB:
      - id: Tetris.Tetromino.TetrominoGo*
        name: TetrominoGo
        nameWithType: Tetromino.TetrominoGo
        qualifiedName: Tetris.Tetromino.TetrominoGo
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.TetrominoGo
  Tetris.Tetromino.RotationState*:
    name:
      CSharp:
      - id: Tetris.Tetromino.RotationState*
        name: RotationState
        nameWithType: Tetromino.RotationState
        qualifiedName: Tetris.Tetromino.RotationState
      VB:
      - id: Tetris.Tetromino.RotationState*
        name: RotationState
        nameWithType: Tetromino.RotationState
        qualifiedName: Tetris.Tetromino.RotationState
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.RotationState
  Color:
    name:
      CSharp:
      - id: Color
        name: Color
        nameWithType: Color
        qualifiedName: Color
        isExternal: true
      VB:
      - id: Color
        name: Color
        nameWithType: Color
        qualifiedName: Color
        isExternal: true
    isDefinition: true
    commentId: '!:Color'
  Tetris.Tetromino.Color*:
    name:
      CSharp:
      - id: Tetris.Tetromino.Color*
        name: Color
        nameWithType: Tetromino.Color
        qualifiedName: Tetris.Tetromino.Color
      VB:
      - id: Tetris.Tetromino.Color*
        name: Color
        nameWithType: Tetromino.Color
        qualifiedName: Tetris.Tetromino.Color
    isDefinition: true
    commentId: Overload:Tetris.Tetromino.Color
  Tetris.Tetromino:
    name:
      CSharp:
      - id: Tetris.Tetromino
        name: Tetromino
        nameWithType: Tetromino
        qualifiedName: Tetris.Tetromino
      VB:
      - id: Tetris.Tetromino
        name: Tetromino
        nameWithType: Tetromino
        qualifiedName: Tetris.Tetromino
    isDefinition: true
    commentId: T:Tetris.Tetromino
  Tetris.TileMap.LineToAnimate*:
    name:
      CSharp:
      - id: Tetris.TileMap.LineToAnimate*
        name: LineToAnimate
        nameWithType: TileMap.LineToAnimate
        qualifiedName: Tetris.TileMap.LineToAnimate
      VB:
      - id: Tetris.TileMap.LineToAnimate*
        name: LineToAnimate
        nameWithType: TileMap.LineToAnimate
        qualifiedName: Tetris.TileMap.LineToAnimate
    isDefinition: true
    commentId: Overload:Tetris.TileMap.LineToAnimate
  Tetris.TileMap.GameOverCube*:
    name:
      CSharp:
      - id: Tetris.TileMap.GameOverCube*
        name: GameOverCube
        nameWithType: TileMap.GameOverCube
        qualifiedName: Tetris.TileMap.GameOverCube
      VB:
      - id: Tetris.TileMap.GameOverCube*
        name: GameOverCube
        nameWithType: TileMap.GameOverCube
        qualifiedName: Tetris.TileMap.GameOverCube
    isDefinition: true
    commentId: Overload:Tetris.TileMap.GameOverCube
  Tetris.TileMap.PlayGrid*:
    name:
      CSharp:
      - id: Tetris.TileMap.PlayGrid*
        name: PlayGrid
        nameWithType: TileMap.PlayGrid
        qualifiedName: Tetris.TileMap.PlayGrid
      VB:
      - id: Tetris.TileMap.PlayGrid*
        name: PlayGrid
        nameWithType: TileMap.PlayGrid
        qualifiedName: Tetris.TileMap.PlayGrid
    isDefinition: true
    commentId: Overload:Tetris.TileMap.PlayGrid
  Tetris:
    name:
      CSharp:
      - name: Tetris
        nameWithType: Tetris
        qualifiedName: Tetris
      VB:
      - name: Tetris
        nameWithType: Tetris
        qualifiedName: Tetris
    isDefinition: true
    commentId: N:Tetris
  Tetris.TileMap.MovementTileMap*:
    name:
      CSharp:
      - id: Tetris.TileMap.MovementTileMap*
        name: MovementTileMap
        nameWithType: TileMap.MovementTileMap
        qualifiedName: Tetris.TileMap.MovementTileMap
      VB:
      - id: Tetris.TileMap.MovementTileMap*
        name: MovementTileMap
        nameWithType: TileMap.MovementTileMap
        qualifiedName: Tetris.TileMap.MovementTileMap
    isDefinition: true
    commentId: Overload:Tetris.TileMap.MovementTileMap
  Tetris.TileMap.InitializeGrid*:
    name:
      CSharp:
      - id: Tetris.TileMap.InitializeGrid*
        name: InitializeGrid
        nameWithType: TileMap.InitializeGrid
        qualifiedName: Tetris.TileMap.InitializeGrid
      VB:
      - id: Tetris.TileMap.InitializeGrid*
        name: InitializeGrid
        nameWithType: TileMap.InitializeGrid
        qualifiedName: Tetris.TileMap.InitializeGrid
    isDefinition: true
    commentId: Overload:Tetris.TileMap.InitializeGrid
  Tetris.TileMap.GameOver*:
    name:
      CSharp:
      - id: Tetris.TileMap.GameOver*
        name: GameOver
        nameWithType: TileMap.GameOver
        qualifiedName: Tetris.TileMap.GameOver
      VB:
      - id: Tetris.TileMap.GameOver*
        name: GameOver
        nameWithType: TileMap.GameOver
        qualifiedName: Tetris.TileMap.GameOver
    isDefinition: true
    commentId: Overload:Tetris.TileMap.GameOver
  Tetris.TileMap:
    name:
      CSharp:
      - id: Tetris.TileMap
        name: TileMap
        nameWithType: TileMap
        qualifiedName: Tetris.TileMap
      VB:
      - id: Tetris.TileMap
        name: TileMap
        nameWithType: TileMap
        qualifiedName: Tetris.TileMap
    isDefinition: true
    commentId: T:Tetris.TileMap
