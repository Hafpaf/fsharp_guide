/// This is a library file
namespace Utilities
module vectors =
    // Calculate length of a vector
    let len (a : float * float) : float =
      sqrt (fst a **2.0 + snd a**2.0)