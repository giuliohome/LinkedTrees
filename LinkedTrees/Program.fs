// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

type Tags<'a> = {
    Tag : 'a
    ParentTag : Tags<'a> option 
}
type Tree<'a> = {
    Tags : Tags<'a>
    Children : Tree<'a> list
}

let rec getPath (node:Tags<'a>) : 'a list =
    match node.ParentTag with
    | None -> [node.Tag]
    | Some parent -> 
        List.append (getPath parent) [node.Tag] 
  
                    
[<EntryPoint>]
let main argv = 

    
    let level0 = {Tag="root"; ParentTag = None } 
    
    let level1a = {Tag="child a"; ParentTag = Some level0 }
    
    let level2a0 = {Tag="grandchild a1"; ParentTag = Some level1a }
    let level2a1 = {Tag="grandchild a2"; ParentTag = Some level1a }
    
    let level2a0Tree = {Tags = level2a0; Children = []}
    let level2a1Tree = {Tags = level2a1; Children = []}
    
    let level1b = {Tag="child b"; ParentTag = Some level0 }
    
    let level2b0 = {Tag="grandchild b1"; ParentTag = Some level1b }
    let level2b1 = {Tag="grandchild b2"; ParentTag = Some level1b }

    let level2b0Tree = {Tags = level2b0; Children = []}
    let level2b1Tree = {Tags = level2b1; Children = []}
    
    let level1aTree = {Tags = level1a; Children = [level2a0Tree; level2a1Tree]}
    let level1bTree = {Tags = level1b; Children = [level2b0Tree; level2b1Tree]}

    let level0Tree = {Tags = level0; Children = [level1aTree; level1bTree]}

    let check = getPath(level2b0Tree.Tags)

    printfn "%s" (System.String.Join("->", check))

    System.Console.ReadKey() |> ignore

    0 
