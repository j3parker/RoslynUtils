using Microsoft.CodeAnalysis.CSharp;

namespace Microsoft.CodeAnalysis {
	public static partial class _Extensions {
		public static TSyntax WithLeadingSpace<TSyntax>( this TSyntax @this ) where TSyntax : SyntaxNode {
			return @this.WithLeadingTrivia( SyntaxFactory.Whitespace( " " ) );
		}

		public static TSyntax WithTrailingSpace<TSyntax>( this TSyntax @this ) where TSyntax : SyntaxNode {
			return @this.WithTrailingTrivia( SyntaxFactory.Whitespace( " " ) );
		}

		public static TSyntax WithSurroundingSpaces<TSyntax>( this TSyntax @this ) where TSyntax : SyntaxNode {
			return @this.WithLeadingSpace().WithTrailingSpace();
		}
	}
}
