using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Refactoring.Pipelines.Test
{
     class AlwaysFailCSharpSyntaxVisitor<T> : CSharpSyntaxVisitor<T>
    {
        public override T VisitIdentifierName(IdentifierNameSyntax node)
        {
            throw new NotImplementedException("IdentifierNameSyntax");
        }

        public override T VisitQualifiedName(QualifiedNameSyntax node)
        {
            throw new NotImplementedException("QualifiedNameSyntax");
        }

        public override T VisitGenericName(GenericNameSyntax node)
        {
            throw new NotImplementedException("GenericNameSyntax");
        }

        public override T VisitTypeArgumentList(TypeArgumentListSyntax node)
        {
            throw new NotImplementedException("TypeArgumentListSyntax");
        }

        public override T VisitAliasQualifiedName(AliasQualifiedNameSyntax node)
        {
            throw new NotImplementedException("AliasQualifiedNameSyntax");
        }

        public override T VisitPredefinedType(PredefinedTypeSyntax node)
        {
            throw new NotImplementedException("PredefinedTypeSyntax");
        }

        public override T VisitArrayType(ArrayTypeSyntax node)
        {
            throw new NotImplementedException("ArrayTypeSyntax");
        }

        public override T VisitArrayRankSpecifier(ArrayRankSpecifierSyntax node)
        {
            throw new NotImplementedException("ArrayRankSpecifierSyntax");
        }

        public override T VisitPointerType(PointerTypeSyntax node)
        {
            throw new NotImplementedException("PointerTypeSyntax");
        }

        public override T VisitNullableType(NullableTypeSyntax node)
        {
            throw new NotImplementedException("NullableTypeSyntax");
        }

        public override T VisitTupleType(TupleTypeSyntax node)
        {
            throw new NotImplementedException("TupleTypeSyntax");
        }

        public override T VisitTupleElement(TupleElementSyntax node)
        {
            throw new NotImplementedException("TupleElementSyntax");
        }

        public override T VisitOmittedTypeArgument(OmittedTypeArgumentSyntax node)
        {
            throw new NotImplementedException("OmittedTypeArgumentSyntax");
        }

        public override T VisitRefType(RefTypeSyntax node)
        {
            throw new NotImplementedException("RefTypeSyntax");
        }

        public override T VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
        {
            throw new NotImplementedException("ParenthesizedExpressionSyntax");
        }

        public override T VisitTupleExpression(TupleExpressionSyntax node)
        {
            throw new NotImplementedException("TupleExpressionSyntax");
        }

        public override T VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
            throw new NotImplementedException("PrefixUnaryExpressionSyntax");
        }

        public override T VisitAwaitExpression(AwaitExpressionSyntax node)
        {
            throw new NotImplementedException("AwaitExpressionSyntax");
        }

        public override T VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
        {
            throw new NotImplementedException("PostfixUnaryExpressionSyntax");
        }

        public override T VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            throw new NotImplementedException("MemberAccessExpressionSyntax");
        }

        public override T VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            throw new NotImplementedException("ConditionalAccessExpressionSyntax");
        }

        public override T VisitMemberBindingExpression(MemberBindingExpressionSyntax node)
        {
            throw new NotImplementedException("MemberBindingExpressionSyntax");
        }

        public override T VisitElementBindingExpression(ElementBindingExpressionSyntax node)
        {
            throw new NotImplementedException("ElementBindingExpressionSyntax");
        }

        public override T VisitImplicitElementAccess(ImplicitElementAccessSyntax node)
        {
            throw new NotImplementedException("ImplicitElementAccessSyntax");
        }

        public override T VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            throw new NotImplementedException("BinaryExpressionSyntax");
        }

        public override T VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            throw new NotImplementedException("AssignmentExpressionSyntax");
        }

        public override T VisitConditionalExpression(ConditionalExpressionSyntax node)
        {
            throw new NotImplementedException("ConditionalExpressionSyntax");
        }

        public override T VisitThisExpression(ThisExpressionSyntax node)
        {
            throw new NotImplementedException("ThisExpressionSyntax");
        }

        public override T VisitBaseExpression(BaseExpressionSyntax node)
        {
            throw new NotImplementedException("BaseExpressionSyntax");
        }

        public override T VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            throw new NotImplementedException("LiteralExpressionSyntax");
        }

        public override T VisitMakeRefExpression(MakeRefExpressionSyntax node)
        {
            throw new NotImplementedException("MakeRefExpressionSyntax");
        }

        public override T VisitRefTypeExpression(RefTypeExpressionSyntax node)
        {
            throw new NotImplementedException("RefTypeExpressionSyntax");
        }

        public override T VisitRefValueExpression(RefValueExpressionSyntax node)
        {
            throw new NotImplementedException("RefValueExpressionSyntax");
        }

        public override T VisitCheckedExpression(CheckedExpressionSyntax node)
        {
            throw new NotImplementedException("CheckedExpressionSyntax");
        }

        public override T VisitDefaultExpression(DefaultExpressionSyntax node)
        {
            throw new NotImplementedException("DefaultExpressionSyntax");
        }

        public override T VisitTypeOfExpression(TypeOfExpressionSyntax node)
        {
            throw new NotImplementedException("TypeOfExpressionSyntax");
        }

        public override T VisitSizeOfExpression(SizeOfExpressionSyntax node)
        {
            throw new NotImplementedException("SizeOfExpressionSyntax");
        }

        public override T VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            throw new NotImplementedException("InvocationExpressionSyntax");
        }

        public override T VisitElementAccessExpression(ElementAccessExpressionSyntax node)
        {
            throw new NotImplementedException("ElementAccessExpressionSyntax");
        }

        public override T VisitArgumentList(ArgumentListSyntax node)
        {
            throw new NotImplementedException("ArgumentListSyntax");
        }

        public override T VisitBracketedArgumentList(BracketedArgumentListSyntax node)
        {
            throw new NotImplementedException("BracketedArgumentListSyntax");
        }

        public override T VisitArgument(ArgumentSyntax node)
        {
            throw new NotImplementedException("ArgumentSyntax");
        }

        public override T VisitNameColon(NameColonSyntax node)
        {
            throw new NotImplementedException("NameColonSyntax");
        }

        public override T VisitDeclarationExpression(DeclarationExpressionSyntax node)
        {
            throw new NotImplementedException("DeclarationExpressionSyntax");
        }

        public override T VisitCastExpression(CastExpressionSyntax node)
        {
            throw new NotImplementedException("CastExpressionSyntax");
        }

        public override T VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
        {
            throw new NotImplementedException("AnonymousMethodExpressionSyntax");
        }

        public override T VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            throw new NotImplementedException("SimpleLambdaExpressionSyntax");
        }

        public override T VisitRefExpression(RefExpressionSyntax node)
        {
            throw new NotImplementedException("RefExpressionSyntax");
        }

        public override T VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            throw new NotImplementedException("ParenthesizedLambdaExpressionSyntax");
        }

        public override T VisitInitializerExpression(InitializerExpressionSyntax node)
        {
            throw new NotImplementedException("InitializerExpressionSyntax");
        }

        public override T VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            throw new NotImplementedException("ObjectCreationExpressionSyntax");
        }

        public override T VisitAnonymousObjectMemberDeclarator(AnonymousObjectMemberDeclaratorSyntax node)
        {
            throw new NotImplementedException("AnonymousObjectMemberDeclaratorSyntax");
        }

        public override T VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            throw new NotImplementedException("AnonymousObjectCreationExpressionSyntax");
        }

        public override T VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            throw new NotImplementedException("ArrayCreationExpressionSyntax");
        }

        public override T VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            throw new NotImplementedException("ImplicitArrayCreationExpressionSyntax");
        }

        public override T VisitStackAllocArrayCreationExpression(StackAllocArrayCreationExpressionSyntax node)
        {
            throw new NotImplementedException("StackAllocArrayCreationExpressionSyntax");
        }

        public override T VisitQueryExpression(QueryExpressionSyntax node)
        {
            throw new NotImplementedException("QueryExpressionSyntax");
        }

        public override T VisitQueryBody(QueryBodySyntax node)
        {
            throw new NotImplementedException("QueryBodySyntax");
        }

        public override T VisitFromClause(FromClauseSyntax node)
        {
            throw new NotImplementedException("FromClauseSyntax");
        }

        public override T VisitLetClause(LetClauseSyntax node)
        {
            throw new NotImplementedException("LetClauseSyntax");
        }

        public override T VisitJoinClause(JoinClauseSyntax node)
        {
            throw new NotImplementedException("JoinClauseSyntax");
        }

        public override T VisitJoinIntoClause(JoinIntoClauseSyntax node)
        {
            throw new NotImplementedException("JoinIntoClauseSyntax");
        }

        public override T VisitWhereClause(WhereClauseSyntax node)
        {
            throw new NotImplementedException("WhereClauseSyntax");
        }

        public override T VisitOrderByClause(OrderByClauseSyntax node)
        {
            throw new NotImplementedException("OrderByClauseSyntax");
        }

        public override T VisitOrdering(OrderingSyntax node)
        {
            throw new NotImplementedException("OrderingSyntax");
        }

        public override T VisitSelectClause(SelectClauseSyntax node)
        {
            throw new NotImplementedException("SelectClauseSyntax");
        }

        public override T VisitGroupClause(GroupClauseSyntax node)
        {
            throw new NotImplementedException("GroupClauseSyntax");
        }

        public override T VisitQueryContinuation(QueryContinuationSyntax node)
        {
            throw new NotImplementedException("QueryContinuationSyntax");
        }

        public override T VisitOmittedArraySizeExpression(OmittedArraySizeExpressionSyntax node)
        {
            throw new NotImplementedException("OmittedArraySizeExpressionSyntax");
        }

        public override T VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node)
        {
            throw new NotImplementedException("InterpolatedStringExpressionSyntax");
        }

        public override T VisitIsPatternExpression(IsPatternExpressionSyntax node)
        {
            throw new NotImplementedException("IsPatternExpressionSyntax");
        }

        public override T VisitThrowExpression(ThrowExpressionSyntax node)
        {
            throw new NotImplementedException("ThrowExpressionSyntax");
        }

        public override T VisitWhenClause(WhenClauseSyntax node)
        {
            throw new NotImplementedException("WhenClauseSyntax");
        }

        public override T VisitDeclarationPattern(DeclarationPatternSyntax node)
        {
            throw new NotImplementedException("DeclarationPatternSyntax");
        }

        public override T VisitConstantPattern(ConstantPatternSyntax node)
        {
            throw new NotImplementedException("ConstantPatternSyntax");
        }

        public override T VisitInterpolatedStringText(InterpolatedStringTextSyntax node)
        {
            throw new NotImplementedException("InterpolatedStringTextSyntax");
        }

        public override T VisitInterpolation(InterpolationSyntax node)
        {
            throw new NotImplementedException("InterpolationSyntax");
        }

        public override T VisitInterpolationAlignmentClause(InterpolationAlignmentClauseSyntax node)
        {
            throw new NotImplementedException("InterpolationAlignmentClauseSyntax");
        }

        public override T VisitInterpolationFormatClause(InterpolationFormatClauseSyntax node)
        {
            throw new NotImplementedException("InterpolationFormatClauseSyntax");
        }

        public override T VisitGlobalStatement(GlobalStatementSyntax node)
        {
            throw new NotImplementedException("GlobalStatementSyntax");
        }

        public override T VisitBlock(BlockSyntax node)
        {
            throw new NotImplementedException("BlockSyntax");
        }

        public override T VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
        {
            throw new NotImplementedException("LocalFunctionStatementSyntax");
        }

        public override T VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            throw new NotImplementedException("LocalDeclarationStatementSyntax");
        }

        public override T VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            throw new NotImplementedException("VariableDeclarationSyntax");
        }

        public override T VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {
            throw new NotImplementedException("VariableDeclaratorSyntax");
        }

        public override T VisitEqualsValueClause(EqualsValueClauseSyntax node)
        {
            throw new NotImplementedException("EqualsValueClauseSyntax");
        }

        public override T VisitSingleVariableDesignation(SingleVariableDesignationSyntax node)
        {
            throw new NotImplementedException("SingleVariableDesignationSyntax");
        }

        public override T VisitDiscardDesignation(DiscardDesignationSyntax node)
        {
            throw new NotImplementedException("DiscardDesignationSyntax");
        }

        public override T VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignationSyntax node)
        {
            throw new NotImplementedException("ParenthesizedVariableDesignationSyntax");
        }

        public override T VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            throw new NotImplementedException("ExpressionStatementSyntax");
        }

        public override T VisitEmptyStatement(EmptyStatementSyntax node)
        {
            throw new NotImplementedException("EmptyStatementSyntax");
        }

        public override T VisitLabeledStatement(LabeledStatementSyntax node)
        {
            throw new NotImplementedException("LabeledStatementSyntax");
        }

        public override T VisitGotoStatement(GotoStatementSyntax node)
        {
            throw new NotImplementedException("GotoStatementSyntax");
        }

        public override T VisitBreakStatement(BreakStatementSyntax node)
        {
            throw new NotImplementedException("BreakStatementSyntax");
        }

        public override T VisitContinueStatement(ContinueStatementSyntax node)
        {
            throw new NotImplementedException("ContinueStatementSyntax");
        }

        public override T VisitReturnStatement(ReturnStatementSyntax node)
        {
            throw new NotImplementedException("ReturnStatementSyntax");
        }

        public override T VisitThrowStatement(ThrowStatementSyntax node)
        {
            throw new NotImplementedException("ThrowStatementSyntax");
        }

        public override T VisitYieldStatement(YieldStatementSyntax node)
        {
            throw new NotImplementedException("YieldStatementSyntax");
        }

        public override T VisitWhileStatement(WhileStatementSyntax node)
        {
            throw new NotImplementedException("WhileStatementSyntax");
        }

        public override T VisitDoStatement(DoStatementSyntax node)
        {
            throw new NotImplementedException("DoStatementSyntax");
        }

        public override T VisitForStatement(ForStatementSyntax node)
        {
            throw new NotImplementedException("ForStatementSyntax");
        }

        public override T VisitForEachStatement(ForEachStatementSyntax node)
        {
            throw new NotImplementedException("ForEachStatementSyntax");
        }

        public override T VisitForEachVariableStatement(ForEachVariableStatementSyntax node)
        {
            throw new NotImplementedException("ForEachVariableStatementSyntax");
        }

        public override T VisitUsingStatement(UsingStatementSyntax node)
        {
            throw new NotImplementedException("UsingStatementSyntax");
        }

        public override T VisitFixedStatement(FixedStatementSyntax node)
        {
            throw new NotImplementedException("FixedStatementSyntax");
        }

        public override T VisitCheckedStatement(CheckedStatementSyntax node)
        {
            throw new NotImplementedException("CheckedStatementSyntax");
        }

        public override T VisitUnsafeStatement(UnsafeStatementSyntax node)
        {
            throw new NotImplementedException("UnsafeStatementSyntax");
        }

        public override T VisitLockStatement(LockStatementSyntax node)
        {
            throw new NotImplementedException("LockStatementSyntax");
        }

        public override T VisitIfStatement(IfStatementSyntax node)
        {
            throw new NotImplementedException("IfStatementSyntax");
        }

        public override T VisitElseClause(ElseClauseSyntax node)
        {
            throw new NotImplementedException("ElseClauseSyntax");
        }

        public override T VisitSwitchStatement(SwitchStatementSyntax node)
        {
            throw new NotImplementedException("SwitchStatementSyntax");
        }

        public override T VisitSwitchSection(SwitchSectionSyntax node)
        {
            throw new NotImplementedException("SwitchSectionSyntax");
        }

        public override T VisitCasePatternSwitchLabel(CasePatternSwitchLabelSyntax node)
        {
            throw new NotImplementedException("CasePatternSwitchLabelSyntax");
        }

        public override T VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
        {
            throw new NotImplementedException("CaseSwitchLabelSyntax");
        }

        public override T VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node)
        {
            throw new NotImplementedException("DefaultSwitchLabelSyntax");
        }

        public override T VisitTryStatement(TryStatementSyntax node)
        {
            throw new NotImplementedException("TryStatementSyntax");
        }

        public override T VisitCatchClause(CatchClauseSyntax node)
        {
            throw new NotImplementedException("CatchClauseSyntax");
        }

        public override T VisitCatchDeclaration(CatchDeclarationSyntax node)
        {
            throw new NotImplementedException("CatchDeclarationSyntax");
        }

        public override T VisitCatchFilterClause(CatchFilterClauseSyntax node)
        {
            throw new NotImplementedException("CatchFilterClauseSyntax");
        }

        public override T VisitFinallyClause(FinallyClauseSyntax node)
        {
            throw new NotImplementedException("FinallyClauseSyntax");
        }

        public override T VisitCompilationUnit(CompilationUnitSyntax node)
        {
            throw new NotImplementedException("CompilationUnitSyntax");
        }

        public override T VisitExternAliasDirective(ExternAliasDirectiveSyntax node)
        {
            throw new NotImplementedException("ExternAliasDirectiveSyntax");
        }

        public override T VisitUsingDirective(UsingDirectiveSyntax node)
        {
            throw new NotImplementedException("UsingDirectiveSyntax");
        }

        public override T VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            throw new NotImplementedException("NamespaceDeclarationSyntax");
        }

        public override T VisitAttributeList(AttributeListSyntax node)
        {
            throw new NotImplementedException("AttributeListSyntax");
        }

        public override T VisitAttributeTargetSpecifier(AttributeTargetSpecifierSyntax node)
        {
            throw new NotImplementedException("AttributeTargetSpecifierSyntax");
        }

        public override T VisitAttribute(AttributeSyntax node)
        {
            throw new NotImplementedException("AttributeSyntax");
        }

        public override T VisitAttributeArgumentList(AttributeArgumentListSyntax node)
        {
            throw new NotImplementedException("AttributeArgumentListSyntax");
        }

        public override T VisitAttributeArgument(AttributeArgumentSyntax node)
        {
            throw new NotImplementedException("AttributeArgumentSyntax");
        }

        public override T VisitNameEquals(NameEqualsSyntax node)
        {
            throw new NotImplementedException("NameEqualsSyntax");
        }

        public override T VisitTypeParameterList(TypeParameterListSyntax node)
        {
            throw new NotImplementedException("TypeParameterListSyntax");
        }

        public override T VisitTypeParameter(TypeParameterSyntax node)
        {
            throw new NotImplementedException("TypeParameterSyntax");
        }

        public override T VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            throw new NotImplementedException("ClassDeclarationSyntax");
        }

        public override T VisitStructDeclaration(StructDeclarationSyntax node)
        {
            throw new NotImplementedException("StructDeclarationSyntax");
        }

        public override T VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            throw new NotImplementedException("InterfaceDeclarationSyntax");
        }

        public override T VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            throw new NotImplementedException("EnumDeclarationSyntax");
        }

        public override T VisitDelegateDeclaration(DelegateDeclarationSyntax node)
        {
            throw new NotImplementedException("DelegateDeclarationSyntax");
        }

        public override T VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
        {
            throw new NotImplementedException("EnumMemberDeclarationSyntax");
        }

        public override T VisitBaseList(BaseListSyntax node)
        {
            throw new NotImplementedException("BaseListSyntax");
        }

        public override T VisitSimpleBaseType(SimpleBaseTypeSyntax node)
        {
            throw new NotImplementedException("SimpleBaseTypeSyntax");
        }

        public override T VisitTypeParameterConstraintClause(TypeParameterConstraintClauseSyntax node)
        {
            throw new NotImplementedException("TypeParameterConstraintClauseSyntax");
        }

        public override T VisitConstructorConstraint(ConstructorConstraintSyntax node)
        {
            throw new NotImplementedException("ConstructorConstraintSyntax");
        }

        public override T VisitClassOrStructConstraint(ClassOrStructConstraintSyntax node)
        {
            throw new NotImplementedException("ClassOrStructConstraintSyntax");
        }

        public override T VisitTypeConstraint(TypeConstraintSyntax node)
        {
            throw new NotImplementedException("TypeConstraintSyntax");
        }

        public override T VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            throw new NotImplementedException("FieldDeclarationSyntax");
        }

        public override T VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
        {
            throw new NotImplementedException("EventFieldDeclarationSyntax");
        }

        public override T VisitExplicitInterfaceSpecifier(ExplicitInterfaceSpecifierSyntax node)
        {
            throw new NotImplementedException("ExplicitInterfaceSpecifierSyntax");
        }

        public override T VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            throw new NotImplementedException("MethodDeclarationSyntax");
        }

        public override T VisitOperatorDeclaration(OperatorDeclarationSyntax node)
        {
            throw new NotImplementedException("OperatorDeclarationSyntax");
        }

        public override T VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node)
        {
            throw new NotImplementedException("ConversionOperatorDeclarationSyntax");
        }

        public override T VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
        {
            throw new NotImplementedException("ConstructorDeclarationSyntax");
        }

        public override T VisitConstructorInitializer(ConstructorInitializerSyntax node)
        {
            throw new NotImplementedException("ConstructorInitializerSyntax");
        }

        public override T VisitDestructorDeclaration(DestructorDeclarationSyntax node)
        {
            throw new NotImplementedException("DestructorDeclarationSyntax");
        }

        public override T VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            throw new NotImplementedException("PropertyDeclarationSyntax");
        }

        public override T VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
        {
            throw new NotImplementedException("ArrowExpressionClauseSyntax");
        }

        public override T VisitEventDeclaration(EventDeclarationSyntax node)
        {
            throw new NotImplementedException("EventDeclarationSyntax");
        }

        public override T VisitIndexerDeclaration(IndexerDeclarationSyntax node)
        {
            throw new NotImplementedException("IndexerDeclarationSyntax");
        }

        public override T VisitAccessorList(AccessorListSyntax node)
        {
            throw new NotImplementedException("AccessorListSyntax");
        }

        public override T VisitAccessorDeclaration(AccessorDeclarationSyntax node)
        {
            throw new NotImplementedException("AccessorDeclarationSyntax");
        }

        public override T VisitParameterList(ParameterListSyntax node)
        {
            throw new NotImplementedException("ParameterListSyntax");
        }

        public override T VisitBracketedParameterList(BracketedParameterListSyntax node)
        {
            throw new NotImplementedException("BracketedParameterListSyntax");
        }

        public override T VisitParameter(ParameterSyntax node)
        {
            throw new NotImplementedException("ParameterSyntax");
        }

        public override T VisitIncompleteMember(IncompleteMemberSyntax node)
        {
            throw new NotImplementedException("IncompleteMemberSyntax");
        }

        public override T VisitSkippedTokensTrivia(SkippedTokensTriviaSyntax node)
        {
            throw new NotImplementedException("SkippedTokensTriviaSyntax");
        }

        public override T VisitDocumentationCommentTrivia(DocumentationCommentTriviaSyntax node)
        {
            throw new NotImplementedException("DocumentationCommentTriviaSyntax");
        }

        public override T VisitTypeCref(TypeCrefSyntax node)
        {
            throw new NotImplementedException("TypeCrefSyntax");
        }

        public override T VisitQualifiedCref(QualifiedCrefSyntax node)
        {
            throw new NotImplementedException("QualifiedCrefSyntax");
        }

        public override T VisitNameMemberCref(NameMemberCrefSyntax node)
        {
            throw new NotImplementedException("NameMemberCrefSyntax");
        }

        public override T VisitIndexerMemberCref(IndexerMemberCrefSyntax node)
        {
            throw new NotImplementedException("IndexerMemberCrefSyntax");
        }

        public override T VisitOperatorMemberCref(OperatorMemberCrefSyntax node)
        {
            throw new NotImplementedException("OperatorMemberCrefSyntax");
        }

        public override T VisitConversionOperatorMemberCref(ConversionOperatorMemberCrefSyntax node)
        {
            throw new NotImplementedException("ConversionOperatorMemberCrefSyntax");
        }

        public override T VisitCrefParameterList(CrefParameterListSyntax node)
        {
            throw new NotImplementedException("CrefParameterListSyntax");
        }

        public override T VisitCrefBracketedParameterList(CrefBracketedParameterListSyntax node)
        {
            throw new NotImplementedException("CrefBracketedParameterListSyntax");
        }

        public override T VisitCrefParameter(CrefParameterSyntax node)
        {
            throw new NotImplementedException("CrefParameterSyntax");
        }

        public override T VisitXmlElement(XmlElementSyntax node)
        {
            throw new NotImplementedException("XmlElementSyntax");
        }

        public override T VisitXmlElementStartTag(XmlElementStartTagSyntax node)
        {
            throw new NotImplementedException("XmlElementStartTagSyntax");
        }

        public override T VisitXmlElementEndTag(XmlElementEndTagSyntax node)
        {
            throw new NotImplementedException("XmlElementEndTagSyntax");
        }

        public override T VisitXmlEmptyElement(XmlEmptyElementSyntax node)
        {
            throw new NotImplementedException("XmlEmptyElementSyntax");
        }

        public override T VisitXmlName(XmlNameSyntax node)
        {
            throw new NotImplementedException("XmlNameSyntax");
        }

        public override T VisitXmlPrefix(XmlPrefixSyntax node)
        {
            throw new NotImplementedException("XmlPrefixSyntax");
        }

        public override T VisitXmlTextAttribute(XmlTextAttributeSyntax node)
        {
            throw new NotImplementedException("XmlTextAttributeSyntax");
        }

        public override T VisitXmlCrefAttribute(XmlCrefAttributeSyntax node)
        {
            throw new NotImplementedException("XmlCrefAttributeSyntax");
        }

        public override T VisitXmlNameAttribute(XmlNameAttributeSyntax node)
        {
            throw new NotImplementedException("XmlNameAttributeSyntax");
        }

        public override T VisitXmlText(XmlTextSyntax node)
        {
            throw new NotImplementedException("XmlTextSyntax");
        }

        public override T VisitXmlCDataSection(XmlCDataSectionSyntax node)
        {
            throw new NotImplementedException("XmlCDataSectionSyntax");
        }

        public override T VisitXmlProcessingInstruction(XmlProcessingInstructionSyntax node)
        {
            throw new NotImplementedException("XmlProcessingInstructionSyntax");
        }

        public override T VisitXmlComment(XmlCommentSyntax node)
        {
            throw new NotImplementedException("XmlCommentSyntax");
        }

        public override T VisitIfDirectiveTrivia(IfDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("IfDirectiveTriviaSyntax");
        }

        public override T VisitElifDirectiveTrivia(ElifDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("ElifDirectiveTriviaSyntax");
        }

        public override T VisitElseDirectiveTrivia(ElseDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("ElseDirectiveTriviaSyntax");
        }

        public override T VisitEndIfDirectiveTrivia(EndIfDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("EndIfDirectiveTriviaSyntax");
        }

        public override T VisitRegionDirectiveTrivia(RegionDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("RegionDirectiveTriviaSyntax");
        }

        public override T VisitEndRegionDirectiveTrivia(EndRegionDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("EndRegionDirectiveTriviaSyntax");
        }

        public override T VisitErrorDirectiveTrivia(ErrorDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("ErrorDirectiveTriviaSyntax");
        }

        public override T VisitWarningDirectiveTrivia(WarningDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("WarningDirectiveTriviaSyntax");
        }

        public override T VisitBadDirectiveTrivia(BadDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("BadDirectiveTriviaSyntax");
        }

        public override T VisitDefineDirectiveTrivia(DefineDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("DefineDirectiveTriviaSyntax");
        }

        public override T VisitUndefDirectiveTrivia(UndefDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("UndefDirectiveTriviaSyntax");
        }

        public override T VisitLineDirectiveTrivia(LineDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("LineDirectiveTriviaSyntax");
        }

        public override T VisitPragmaWarningDirectiveTrivia(PragmaWarningDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("PragmaWarningDirectiveTriviaSyntax");
        }

        public override T VisitPragmaChecksumDirectiveTrivia(PragmaChecksumDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("PragmaChecksumDirectiveTriviaSyntax");
        }

        public override T VisitReferenceDirectiveTrivia(ReferenceDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("ReferenceDirectiveTriviaSyntax");
        }

        public override T VisitLoadDirectiveTrivia(LoadDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("LoadDirectiveTriviaSyntax");
        }

        public override T VisitShebangDirectiveTrivia(ShebangDirectiveTriviaSyntax node)
        {
            throw new NotImplementedException("ShebangDirectiveTriviaSyntax");
        }

        public override bool Equals(object obj) { return base.Equals(obj); }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override string ToString() { return base.ToString(); }
    }
}
