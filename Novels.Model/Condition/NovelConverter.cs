namespace Novels.Model
{
	public sealed class NovelConverter : ConvertCondition
	{
        public override sealed ConverterAction Action
        {
            get { return ConverterAction.Novel; }
        }
    }
}
