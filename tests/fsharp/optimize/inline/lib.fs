module Test.Lib

#nowarn "9"

open System.Runtime.InteropServices

[<Struct>]
[<StructLayout (LayoutKind.Sequential)>]
type Vector3 =
    val x : single
    val y : single
    val z : single

    new (x, y, z) = { x = x; y = y; z = z }

[<RequireQualifiedAccess>]
[<CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Vector3 =
    let inline dot (v1: Vector3) (v2: Vector3) =
        v1.x * v2.x + v1.y * v2.y + v1.z * v2.z

[<Struct>]
[<StructLayout (LayoutKind.Sequential)>]
type Vector3MutableField =
    val x : single
    val mutable y : single
    val z : single

    new (x, y, z) = { x = x; y = y; z = z }

[<RequireQualifiedAccess>]
[<CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Vector3MutableField =
    let inline dot (v1: Vector3MutableField) (v2: Vector3MutableField) =
        v1.x * v2.x + v1.y * v2.y + v1.z * v2.z

[<StructLayout (LayoutKind.Sequential)>]
type Vector3NestedMutableField =
    val x : single
    val mutable y : Vector3MutableField
    val z : single

    new (x, y, z) = { x = x; y = y; z = z }

[<RequireQualifiedAccess>]
[<CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Vector3NestedMutableField =
    let inline test (v1: Vector3NestedMutableField) (v2: Vector3NestedMutableField) =
        v1.x * v2.x + v1.y.y * v2.y.y + v1.z * v2.z

[<StructLayout (LayoutKind.Sequential)>]
type Vector3Generic<'T> =
    val x : 'T
    val mutable y : 'T
    val z : 'T

    new (x, y, z) = { x = x; y = y; z = z }

[<RequireQualifiedAccess>]
[<CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Vector3Generic =
    let inline test (v1: Vector3Generic<int>) (v2: Vector3Generic<int>) =
        v1.x * v2.x + v1.y * v2.y + v1.z * v2.z