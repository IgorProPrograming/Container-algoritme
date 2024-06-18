using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Container_algoritme
{
    public class Ship
    {
        public List<Row> rows { get; private set; }

        int length;
        int width;

        public Ship(int _width, int _length)
        {
            rows = new List<Row>();

            length = _length;
            width = _width;

            for (int i = 0; i < length; i++)
            {
                rows.Add(new Row(width));
            }
        }

        public string GetWebString()
        {
            WebStringFactory webStringFactory = new WebStringFactory();
            return webStringFactory.CreateString(length, width, rows);
        }

        public void AddContainers(List<Container> containers)
        {
            foreach (var container in containers.Where(x => x.isCooled))
            {
                SortCooledContainer(container);
            }

            foreach (var container in containers.Where(x => !x.isValuable && !x.isCooled))
            {
                SortNormalContainer(container);
            }

            foreach (var container in containers.Where(x => x.isValuable))
            {
                SortValuableContainer(container);
            }
        }

        private void SortCooledContainer(Container container)
        {
            int frontRow = 0;
            rows[frontRow].TryAddContainer(container);
        }

        private void SortNormalContainer(Container container)
        {
            foreach (var row in rows)
            {
                if (row.TryAddContainer(container))
                {
                    break;
                }
            }
        }

        private void SortValuableContainer(Container container)
        {
            foreach (var row in rows)
            {
                if (TryAddValuableContainer(row, container))
                {
                    break;
                }
            }
        }

        private bool TryAddValuableContainer(Row row, Container container)
        {
            int rowIndex = rows.IndexOf(row);
            int stackIndex = 0;

            foreach (var stack in rows[rowIndex].stacks)
            {
                if (CheckOtherStackAndTryAdd(rowIndex, stackIndex, container))
                {
                    return true;
                }
                stackIndex++;
            }
            return false;
        }


        private bool TryAddValuableToStack(int rowIndex, int stackIndex, Container container)
        {
            if (rows[rowIndex].TryAddContainer(container, stackIndex))
            {
                return true;
            }
            return false;
        }

        private bool CheckOtherStackAndTryAdd(int rowIndex, int stackIndex, Container container)
        {
            Row rowBeforeCurrentRow = GetPreviousRow(rowIndex);
            Row rowAfterCurrentRow = GetNextRow(rowIndex);

            if (!WillBlockValuableContainer(rowBeforeCurrentRow, rowAfterCurrentRow, stackIndex))
            {
                if (CompareStacks(rowIndex, stackIndex, container, rowBeforeCurrentRow, rowAfterCurrentRow))
                {
                    TryAddValuableToStack(rowIndex, stackIndex, container);
                }
            }
            return false;
        }

        private Row GetPreviousRow(int currentRowIndex)
        {
            if (currentRowIndex > 0)
            {
                return rows[currentRowIndex - 1];
            }
            else
            {
                return null;
            }
        }

        private Row GetNextRow(int currentRowIndex)
        {
            if (currentRowIndex < rows.Count - 1)
            {
                return rows[currentRowIndex + 1];
            }
            else
            {
                return null;
            }
        }

        private bool WillBlockValuableContainer(Row rowBefore, Row rowAfter, int stackIndex)
        {
            bool willBlock = false;
            if (rowBefore != null)
            {
                if (rowBefore.stacks[stackIndex].Containers.Any())
                {
                    if (rowBefore.stacks[stackIndex].Containers.Last().isValuable)
                    {
                        willBlock = true;
                    }
                }
            }

            if (rowAfter != null)
            {
                if (rowAfter.stacks[stackIndex].Containers.Any())
                {
                    if (rowAfter.stacks[stackIndex].Containers.Last().isValuable)
                    {
                        willBlock = true;
                    }
                }
            }
            return willBlock;
        }


        private bool CompareStacks(int rowIndex, int stackIndex, Container container, Row rowBeforeCurrentRow, Row rowAfterCurrentRow)
        {
            int stackHeight = rows[rowIndex].GetStackHeight(stackIndex);
            int stackHeightBefore = rowBeforeCurrentRow?.GetStackHeight(stackIndex) ?? -1;
            int stackHeightAfter = rowAfterCurrentRow?.GetStackHeight(stackIndex) ?? -1;

            // Check if the current stack is suitable for a valuable container without blocking access to other valuable containers
            bool canPlaceWithoutBlocking = !WillBlockValuableContainer(rowBeforeCurrentRow, rowAfterCurrentRow, stackIndex);
            if (canPlaceWithoutBlocking)
            {
                // If there's no row before or after, or if the current stack height is greater or equal to adjacent stacks, try to add
                if ((rowBeforeCurrentRow == null || stackHeight >= stackHeightBefore) &&
                    (rowAfterCurrentRow == null || stackHeight >= stackHeightAfter))
                {
                    return TryAddValuableToStack(rowIndex, stackIndex, container);
                }
            }

            return false;
        }
    }
}


