using System.Linq;

namespace Microsoft.CodeAnalysis.CSharp.Syntax {
	public static partial class _Extensions {
		private static readonly SyntaxToken ReadOnlySyntax = SyntaxFactory.Token(
			SyntaxFactory.TriviaList(),
			SyntaxKind.ReadOnlyKeyword,
			SyntaxFactory.TriviaList( SyntaxFactory.Space )
		);

		public static bool HasModifier( this FieldDeclarationSyntax @this, SyntaxKind kind ) {
			return @this.Modifiers.Any( m => m.Kind() == kind );
		}

		public static bool IsReadOnly( this FieldDeclarationSyntax @this ) {
			return @this.HasModifier( SyntaxKind.ReadOnlyKeyword );
		}

		public static FieldDeclarationSyntax AsReadOnly( this FieldDeclarationSyntax @this ) {
			if( @this.IsReadOnly() ) {
				return @this;
			}

			var newModifiers = @this.Modifiers.Add( ReadOnlySyntax );

			return @this.WithModifiers( newModifiers );
		}
	}
}
